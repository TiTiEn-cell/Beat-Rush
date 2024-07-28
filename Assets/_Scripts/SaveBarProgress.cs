using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveBarProgress : MonoBehaviour
{
    //Public variables
    //Private variables
    [SerializeField] private string nameLevel;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    Slider progressSlider;
    //Protected variables
    private void Awake()
    {
        progressSlider = GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        progressSlider.value = PlayerPrefs.GetFloat("bestProgress_"+nameLevel);
        textMeshProUGUI.text = Mathf.FloorToInt(progressSlider.value * 100) + "%";
    }
}
