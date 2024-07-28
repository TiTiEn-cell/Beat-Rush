using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeFlyFollowPlayer : MonoBehaviour
{
    //Public variables
    //Private variables
    [SerializeField] private float speedFollow = 5;
    private PlayerController playerController;
    //Protected variables


    private void Awake()
    {
        playerController = GameObject.Find("PlayerController").GetComponent<PlayerController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //Không follow player khi player sài ability across the wall
        if (playerController.playerAcrossTheWall.isAcrossTheWall) return;
        FollowPlayer();
    }

    void FollowPlayer()
    {
        //Xác định hướng player
        Vector2 followDirection = playerController.transform.position - transform.position;

        //chuẩn hóa đồng đều lại vector 
        followDirection.Normalize();

        //Di chuyển theo player
        transform.parent.Translate(followDirection * speedFollow * Time.deltaTime, Space.World);
    }
}
