using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageColorChange : MonoBehaviour
{
    //Public variables
    //Private variables
    [SerializeField] private Image image;
    [SerializeField] private float speedChangeColor;
    private ColorManager colorManager;
    //Protected variables

    private void Awake()
    {
        image = GetComponent<Image>();
        colorManager = GameObject.Find("ColorManager").GetComponent<ColorManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        image.color = Color.Lerp(image.color, RandomColor(), speedChangeColor * Time.deltaTime);
    }

    private Color RandomColor()
    {
        return new Color(Random.value, Random.value, Random.value);
    }
}
