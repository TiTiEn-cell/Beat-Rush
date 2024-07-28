using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerSpeedUp playerSpeedUp;
    public PlayerAcrossTheWall playerAcrossTheWall;
    public PlayerJumpSpace playerJumpSpace;
    public PlayerCollider playerCollider;

    private void Awake()
    {
        playerMovement = transform.parent.Find("PlayerMovement").GetComponent<PlayerMovement>();
        playerSpeedUp = transform.parent.Find("PlayerSpeedUp").GetComponent<PlayerSpeedUp>();
        playerAcrossTheWall = transform.parent.Find("PlayerAcrossTheWall").GetComponent<PlayerAcrossTheWall>();
        playerJumpSpace = transform.parent.Find("PlayerJumpSpace").GetComponent<PlayerJumpSpace>();
        playerCollider = transform.parent.Find("PlayerCollider").GetComponent<PlayerCollider>();
    }
}
