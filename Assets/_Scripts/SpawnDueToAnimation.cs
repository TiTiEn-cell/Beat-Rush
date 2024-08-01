using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDueToAnimation : MonoBehaviour
{
    //Public variables
    //Private variables
    [SerializeField] private GameObject objPrefab;
    //Protected variables


    public void SpawnObj()
    {
        Instantiate(objPrefab,transform.parent.position,transform.parent.rotation);
        transform.parent.gameObject.SetActive(false);
    }
}
