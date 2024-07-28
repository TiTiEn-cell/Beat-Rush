using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole1Controller : MonoBehaviour
{
    public SetActiveByDistance setActiveByDistance;
    public void Awake()
    {
        setActiveByDistance = transform.parent.Find("Hole1SetActiveByDistance").GetComponent<SetActiveByDistance>();
    }
}
