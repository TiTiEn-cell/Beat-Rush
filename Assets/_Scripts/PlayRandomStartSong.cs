using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayRandomStartSong : MonoBehaviour
{
    //Public variables
    //Private variables
    [SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();
    [SerializeField] private AudioSource musicManager;
    [SerializeField] private Image[] images;
    //Protected variables

    private void Awake()
    {
        musicManager = GameObject.Find("MusicManager").GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        musicManager.clip = audioClips[PlayRandomList()];
        musicManager.Play();
        DisableAllImage();
    }

    int PlayRandomList()
    {
        return Random.Range(0, audioClips.Count);
    }
    public void DisableAllImage()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].enabled = false;
        }
    }

}
