using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SniperNoAimController : MonoBehaviour
{
    //Public variables
    public SniperNoAimShoot sniperNoAimShoot;
    public SniperNoAimLazer sniperNoAimLazer;
    //Private variables
    //Protected variables

    private void Awake()
    {
        sniperNoAimShoot = transform.parent.Find("SniperNoAimShoot").GetComponent<SniperNoAimShoot>();
        sniperNoAimLazer = transform.parent.Find("SniperNoAimLazer").GetComponent<SniperNoAimLazer>();
    }

}
