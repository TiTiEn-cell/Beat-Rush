using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImmotal : MonoBehaviour
{
    //Public variables
    //Private variables
    [SerializeField] private float timeImmotal = 3f;
    private PlayerController playerController;
    //Protected variables

    private void Awake()
    {
        playerController = transform.parent.Find("PlayerController").GetComponent<PlayerController>();
    }

    public IEnumerator Immotal()
    {
        yield return new WaitForSeconds(timeImmotal);
        playerController.playerCollider.isDeath = false;
    }
}
