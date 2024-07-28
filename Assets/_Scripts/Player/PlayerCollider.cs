using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    //Public variables
    public bool isDeath;
    //Private variables
    private SpawnManager spawnManager;
    private MusicManager musicManager;
    private int deathCount;
    //Protected variables

    private void Awake()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        deathCount = 0;
        isDeath = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDeath) return;
        if (collision.gameObject.CompareTag("Enemy"))
        {
            deathCount++;
            isDeath = true;
            if (deathCount == 1)
            {
                GameManager.instance.GetReviveUI();
                GameManager.instance.speedUpBtn.gameObject.SetActive(false);
                //GameManager.instance.movementBtn.gameObject.SetActive(false);
                transform.parent.gameObject.SetActive(false);
                spawnManager.gameObject.SetActive(false);
                musicManager.PauseMusic();
            }
            else
            {
                GameManager.instance.GetRestartUI();
                GameManager.instance.speedUpBtn.gameObject.SetActive(false);
                GameManager.instance.movementBtn.gameObject.SetActive(false);
                transform.parent.gameObject.SetActive(false);
                spawnManager.gameObject.SetActive(false);
                musicManager.PauseMusic();
            }
            
        }
    }
}
