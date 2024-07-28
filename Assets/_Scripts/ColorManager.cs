using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    //Public variables
    //Private variables
    public float speedChangeColor = 2f;
    public Color targetColor;
    //Protected variables

    private void Start()
    {
        targetColor = RandomColor();
    }


    public void CheckDistanceColor(Color startColor)
    {
        if (Vector4.Distance(startColor,targetColor) < 0.1f)
        {
            targetColor = RandomColor();
        }
    }

    public Color RandomColor()
    {
        return new Color(Random.value,Random.value,Random.value);
    }
}
