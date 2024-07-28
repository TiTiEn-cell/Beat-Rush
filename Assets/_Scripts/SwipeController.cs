using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class SwipeController : MonoBehaviour, IEndDragHandler, IDragHandler
{
    [SerializeField] int maxPage;
    [SerializeField] RectTransform contentsReactTransform;
    [SerializeField] Vector3 distancePos;
    [SerializeField] float leanTime;
    [SerializeField] LeanTweenType leanTweenType;
    [SerializeField] Image[] barLevels;
    [SerializeField] Sprite barOpen, barClose;
    [SerializeField] Button nextBtn, previousBtn;
    [SerializeField] List<Color> listColor;
    [SerializeField] Light2D lightBackground;
    [SerializeField] float timeChangeColor;
    [SerializeField] AudioClip[] musicClip;
    [SerializeField] ParticleSystem[] particleSystems;
    int currentPage;
    Vector3 targetPos;
    private LTDescr tween;
    float maxDrag;
    AudioSource audioSource;
    float saveTargetPos;
    int saveCurrentPage;

    private void Awake()
    {
        audioSource = GameObject.Find("MusicManager").GetComponent<AudioSource>();
    }

    private void Start()
    {
        
        if (!PlayerPrefs.HasKey("savePage"))
        {
            currentPage = 1;
        }
        else
        {
            currentPage = PlayerPrefs.GetInt("savePage");
        }

        if (!PlayerPrefs.HasKey("saveTargetPosX"))
        {
            targetPos = contentsReactTransform.localPosition;
        }
        else
        {
            targetPos.x = PlayerPrefs.GetFloat("saveTargetPosX");
            targetPos.y = PlayerPrefs.GetFloat("saveTargetPosY");
        } 
        MovePage();
        ChangeMusic();
        PlayParticleSystem();
        maxDrag = Screen.width / 10;
    }
    public void Next()
    {
        if (currentPage < maxPage)
        {
            currentPage++;
            targetPos += distancePos;
            MovePage();
            ChangeMusic();
            PlayParticleSystem();
        }
        else
        {
            currentPage = 1;
            targetPos -= distancePos * (maxPage - 1);
            MovePage();
            ChangeMusic();
            PlayParticleSystem();
        }
    }

    public void Previous()
    {
        if (currentPage > 1)
        {
            currentPage--;
            targetPos -= distancePos;
            MovePage();
            ChangeMusic();
            PlayParticleSystem();
        }
        else
        {
            currentPage = maxPage;
            targetPos += distancePos * (maxPage-1);
            MovePage();
            ChangeMusic();
            PlayParticleSystem();
        }
    }

    void MovePage()
    {
        if (tween != null) tween.reset();

        tween = contentsReactTransform.LeanMoveLocal(targetPos, leanTime).setEase(leanTweenType);
        PlayerPrefs.SetInt("savePage", currentPage);
        PlayerPrefs.SetFloat("saveTargetPosX", targetPos.x);
        PlayerPrefs.SetFloat("saveTargetPosY", targetPos.y);
        UpdateBar();
        ChangeBackgroundColor();
        //UpdateArrowButton();
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.position.x - eventData.pressPosition.x) > maxDrag)
        {
            
            if (eventData.position.x > eventData.pressPosition.x)
            {
                Previous();
            }
            else
            {
                Next();
            }
        }
        else
        {
            MovePage();

        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.position.x - eventData.pressPosition.x) > Screen.width / 2)
        {
            particleSystems[currentPage - 1].Stop();
            if (eventData.position.x > eventData.pressPosition.x)
            {
                if (currentPage > 1)
                {
                    Color targetColor = listColor[currentPage - 2];
                    LeanTween.value(lightBackground.gameObject, UpdateColor, lightBackground.color, targetColor, timeChangeColor).setEase(leanTweenType);
                }
            }
            else
            {
                if (currentPage < maxPage)
                {
                    Color targetColor = listColor[currentPage];
                    LeanTween.value(lightBackground.gameObject, UpdateColor, lightBackground.color, targetColor, timeChangeColor).setEase(leanTweenType);
                }
            }

        }
    }


    void UpdateBar()
    {
        foreach (Image barLevel in barLevels)
        {
            barLevel.sprite = barClose;
        }
        barLevels[currentPage - 1].sprite = barOpen;
    }

    void UpdateArrowButton()
    {
        nextBtn.interactable = true;
        previousBtn.interactable = true;
        if (currentPage == maxPage)
        {
            nextBtn.interactable = false;
        }
        else if (currentPage == 1)
        {
            previousBtn.interactable = false;
        }

    }

    void ChangeBackgroundColor()
    {
        if (currentPage - 1 < listColor.Count)
        {
            Color targetColor = listColor[currentPage - 1];
            LeanTween.value(lightBackground.gameObject, UpdateColor, lightBackground.color, targetColor, timeChangeColor).setEase(leanTweenType);
        }
    }

    void UpdateColor(Color color)
    {
        lightBackground.color = color;
    }

    void ChangeMusic()
    {
        audioSource.clip = musicClip[currentPage - 1];
        audioSource.Play();
    }

    void PlayParticleSystem()
    {
        for (int i = 0; i < particleSystems.Length; i++)
        {
            particleSystems[i].gameObject.SetActive(false);
        }
        if (currentPage <= particleSystems.Length)
        {
            particleSystems[currentPage - 1].gameObject.SetActive(true);
            particleSystems[currentPage - 1].Play();
        }
        
    }

}
