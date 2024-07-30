using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSongToPlay : MonoBehaviour
{
    //Public variables
    //Private variables
    [SerializeField] private AudioClip musicClip;
    [SerializeField] private AudioSource musicManager;
    [SerializeField] private Image image;
    //[SerializeField] private ListImageDisable imageDisable;
    [SerializeField] private PlayRandomStartSong song;
    //Protected variables

    private void Awake()
    {
        musicManager = GameObject.Find("MusicManager").GetComponent<AudioSource>();
        image = GetComponent<Image>();
        //imageDisable = GetComponentInParent<ListImageDisable>();
        song = GameObject.Find("PlayRandomStartSong").GetComponent<PlayRandomStartSong>();
    }

    public void ChooseSong()
    {
        if (musicManager.clip == musicClip) return;
        musicManager.clip = musicClip;
        musicManager.Play();
        song.DisableAllImage();
        image.enabled = true;
    }

    private void OnEnable()
    {    
        if (musicManager.clip == musicClip)
        {
            image.enabled = true; ;
        }
    }
}
