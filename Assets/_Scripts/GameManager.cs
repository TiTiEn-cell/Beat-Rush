using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    [Header("GameUI")]//----------------------------------------------//
    public string levelName;
    public GameObject reviveUI;
    public GameObject restartUI;
    public GameObject pauseUI;
    public GameObject newBestUI;
    public TextMeshProUGUI countDownText;
    public Slider barProgressInGame;
    public TextMeshProUGUI textBarProgress;
    public Button pauseBtn;
    public Button speedUpBtn;
    public GameObject movementBtn;

    [Header("HomeUI")]//----------------------------------------------//
    public GameObject settingUI;
    public Button settingBtn;
    public Image musicBtn;
    public Sprite musicOn, musicOff;


    [Header("Side")]//----------------------------------------------//
    public float progress;
    [SerializeField] private float timeCountDown = 5f;
    [SerializeField] private float highestProgress;
    private bool hasStartedTween;

    private GameObject player;
    private PlayerImmotal playerImmotal;
    private PlayerAnimator playerAnimator;
    private GameObject spawnManager;
    private MusicManager musicManager;
    private float previousTimeCountDown;
    //Protected variables

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        //______________________________UI___________________________________________

        //___________________________________________________________________________
        player = GameObject.Find("Player");
        spawnManager = GameObject.Find("SpawnManager");
        musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();
        if (player != null)
        {
            playerImmotal = player.GetComponentInChildren<PlayerImmotal>();
            playerAnimator = player.transform.Find("PlayerAnimator").GetComponent<PlayerAnimator>();
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        if (reviveUI != null) reviveUI.SetActive(false);
        if (restartUI != null) restartUI.SetActive(false);
        if (barProgressInGame != null) barProgressInGame.gameObject.SetActive(false);
        if (pauseUI != null) pauseUI.SetActive(false);
        if (newBestUI != null) newBestUI.SetActive(false);
        if (countDownText != null) countDownText.text = "5";
        if (settingUI != null) settingUI.SetActive(false);
        previousTimeCountDown = Mathf.FloorToInt(timeCountDown);
        CheckMusicBtnSprite();

        if (PlayerPrefs.HasKey("bestProgress_" + levelName))
        {
            highestProgress = PlayerPrefs.GetFloat("bestProgress_" + levelName);
        }
        else
        {
            highestProgress = 0;
        }

    }

    // Update is called once per frame
    void Update()
    {
        CountDownText();
        BarProgress();
        TrackingBarProgress();
    }

    void TrackingBarProgress()
    {
        if (barProgressInGame != null)
        {
            progress = barProgressInGame.value;
        }
    }

    void CheckMusicBtnSprite()
    {
        if (PlayerPrefs.GetString("imageMusic") == "turn off")
        {
            if (musicBtn != null) musicBtn.sprite = musicOff;
        }
        else if (PlayerPrefs.GetString("imageMusic") == "turn on")
        {
            if (musicBtn != null) musicBtn.sprite = musicOn;
        }
    }

    public void ButtonRestart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ButtonRevive()
    {
        reviveUI.SetActive(false);
        barProgressInGame.gameObject.SetActive(false);
        player.SetActive(true);
        movementBtn.SetActive(true);
        speedUpBtn.gameObject.SetActive(true);
        pauseBtn.gameObject.SetActive(true);
        musicManager.PlayMusic();
        spawnManager.SetActive(true);
        playerAnimator.ReviveAnim();
        StartCoroutine(playerImmotal.Immotal());
    }

    public void ButtonClose()
    {
        timeCountDown--;
    }

    public void ButtonBack()
    {
        settingUI.SetActive(false);
        settingBtn.gameObject.SetActive(true);
    }

    void CountDownText()
    {
        if (reviveUI != null && reviveUI.activeInHierarchy)
        {
            float currentTimeCountDown = Mathf.FloorToInt(timeCountDown);
            // Check if timeCountDown has decreased by at least 1 unit
            if (currentTimeCountDown < previousTimeCountDown)
            {
                if (reviveUI != null)
                {
                    LeanTween.scale(reviveUI, new Vector3(1.2f, 1.05f, 1.2f), 0.1f);
                    LeanTween.scale(reviveUI, Vector3.one, 0.1f).setDelay(0.1f);
                }
                previousTimeCountDown = currentTimeCountDown;
            }

            timeCountDown -= Time.deltaTime;
            if (timeCountDown <= 0)
            {
                timeCountDown = 0f;
                GetRestartUI();

            }

            if (countDownText != null) countDownText.text = "" + Mathf.Round(timeCountDown);
        }

    }


    void BarProgress()
    {
        if (barProgressInGame != null && musicManager != null)
        {
            if (!restartUI.activeInHierarchy)
        {

                barProgressInGame.value = musicManager.GetMusicTime() / musicManager.GetMusicLength();
            
        }
        else
        {
            if (!hasStartedTween)
            {
                hasStartedTween = true;
                barProgressInGame.value = 0;
                LeanTween.value(gameObject, 0f, progress, 4f).setEase(LeanTweenType.easeOutQuad).setOnUpdate((float val) =>
                {
                    barProgressInGame.value = val;
                    textBarProgress.text = Mathf.FloorToInt(val * 100) + "%";
                    if (val > highestProgress)
                    {
                        newBestUI.SetActive(true);
                    }
                });
            }
        }
        }
    }


    public void ButtonPause()
    {
        pauseUI.SetActive(true);
        pauseBtn.gameObject.SetActive(false);
        Time.timeScale = 0.001f;
        musicManager.PauseMusic();
    }

    public void ButtonPlayContinue()
    {
        Time.timeScale = 1f;
        musicManager.PlayMusic();
        pauseUI.SetActive(false);
        pauseBtn.gameObject.SetActive(true);
    }

    public void ButtonSetting()
    {
        GetSettingUI();
        settingBtn.gameObject.SetActive(false);
    }

    public void ButtonMusic()
    {
        if (musicManager.GetMusicVolumeTurnOn())
        {
            musicManager.musicVolume = 0f;
            musicBtn.sprite = musicOff;
            PlayerPrefs.SetString("imageMusic", "turn off");
        }
        else
        {
            musicManager.musicVolume = 1f;
            musicBtn.sprite = musicOn;
            PlayerPrefs.SetString("imageMusic", "turn on");
        }
    }

    public void GetReviveUI()
    {
        restartUI.SetActive(false);
        reviveUI.SetActive(true);
        pauseBtn.gameObject.SetActive(false);

    }

    public void GetRestartUI()
    {
        if (reviveUI != null) reviveUI.SetActive(false);
        if (restartUI != null) restartUI.SetActive(true);
        barProgressInGame.gameObject.SetActive(true);
        pauseBtn.gameObject.SetActive(false);

        if (!PlayerPrefs.HasKey("bestProgress_" + levelName))
        {
            PlayerPrefs.SetFloat("bestProgress_" + levelName, progress);
        }
        else
        {
            if (progress > PlayerPrefs.GetFloat("bestProgress_" + levelName))
            {
                PlayerPrefs.SetFloat("bestProgress_" + levelName, progress);
            }
        }
    }

    public void GetSettingUI()
    {
        settingUI.SetActive(true);
    }
}