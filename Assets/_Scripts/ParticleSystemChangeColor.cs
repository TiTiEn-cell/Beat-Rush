using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParticleSystemChangeColor : MonoBehaviour
{
    //Public variables
    //Private variables
    private ParticleSystemRenderer particleSystemRenderer;
    private ColorManager colorManager;

    //Protected variables

    private void Awake()
    {
        particleSystemRenderer = GameObject.Find("Particle System").GetComponent<ParticleSystemRenderer>();
        colorManager = GameObject.Find("ColorManager").GetComponent<ColorManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        particleSystemRenderer.material.color = Vector4.Lerp(particleSystemRenderer.material.color, colorManager.targetColor, colorManager.speedChangeColor * Time.deltaTime);
        colorManager.CheckDistanceColor(particleSystemRenderer.material.color);
    }
}
