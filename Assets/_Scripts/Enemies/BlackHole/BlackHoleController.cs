using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleController : MonoBehaviour
{
    //Public variables
    public BlackHoleAnimator blackHoleAnimator;
    public BlackHolePull blackHolePull;
    //Private variables
    //Protected variables

    private void Awake()
    {
        blackHoleAnimator = transform.parent.Find("BlackHoleSprite").GetComponent<BlackHoleAnimator>();
        blackHolePull = transform.parent.Find("BlackHolePull").GetComponent<BlackHolePull>();
    }


}
