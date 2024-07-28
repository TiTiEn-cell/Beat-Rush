using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BackgroundChangeLight : MonoBehaviour
{
    //Public variables
    //Private variables
    private new Light2D light;
    private ColorManager colorManager;
    //Protected variables

    private void Awake()
    {
        colorManager = GameObject.Find("ColorManager").GetComponent<ColorManager>();
        light = GetComponent<Light2D>();
    }


    // Update is called once per frame
    void Update()
    {
        light.color = Color.Lerp(light.color, colorManager.targetColor, colorManager.speedChangeColor * Time.deltaTime);
        colorManager.CheckDistanceColor(light.color);
    }
}
