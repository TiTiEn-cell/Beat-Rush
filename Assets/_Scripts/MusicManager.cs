using UnityEngine;

public class MusicManager : MonoBehaviour
{
    //Public variables
    public AudioSource audioSource;
    public float musicVolume;
    //Private variables
    public float[] sample;
    public static float SampleValue { get; private set; }
    //Protected variables

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        musicVolume = PlayerPrefs.GetFloat("music");
        audioSource.volume = musicVolume;
        sample = new float[128];
    }

    private void Update()
    {
        Debug.Log("Time: " + GetMusicTime());
        audioSource.volume = musicVolume;
        GetSpectrumData();
        if (sample != null && sample.Length > 0)
        {
            SampleValue = sample[0] * 100;
        }
        PlayerPrefs.SetFloat("music", musicVolume);

    }


    public float GetMusicTime()
    {
        return audioSource.time;
    }

    public float GetMusicLength()
    {
        return audioSource.clip.length;
    }

    public void PauseMusic()
    {
        audioSource.Pause();
    }

    public void PlayMusic()
    {
        audioSource.Play();
    }

    public bool GetMusicVolumeTurnOn()
    {
        return audioSource.volume > 0f;
    }

    void GetSpectrumData()
    {
        audioSource.GetSpectrumData(sample, 0, FFTWindow.Hamming);
    }

}
