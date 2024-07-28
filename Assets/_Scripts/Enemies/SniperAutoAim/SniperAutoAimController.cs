using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SniperAutoAimController : MonoBehaviour
{
    //Public variables
    public SniperAutoAimShoot sniperAutoAimShoot;
    public SniperAutoAimLazer sniperAutoAimLazer;
    //Private variables
    //Protected variables

    private void Awake()
    {
        sniperAutoAimShoot = transform.parent.Find("SniperAutoAimShoot").GetComponent<SniperAutoAimShoot>();
        sniperAutoAimLazer = transform.parent.Find("SniperAutoAimLazer").GetComponent<SniperAutoAimLazer>();
    }

}
