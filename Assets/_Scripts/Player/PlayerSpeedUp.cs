using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedUp : MonoBehaviour
{
    //Public variables
    //Private variables
    private PlayerController playerController;
    private Rigidbody2D rb;
    private TrailRenderer tr;
    [SerializeField] private float speedUp = 5f; // Tốc độ được + vào khi sử dụng kĩ năng tăng tốc
    [SerializeField] private float speedUpTime = 0.5f; // Thời gian kĩ năng tăng tốc kéo dài
    [SerializeField] private float speedUpCoolDown = 1f; // Thời gian cooldown kĩ năng tăng tốc
    [SerializeField] private float startSpeed; // Tốc độ ban đầu player
    [SerializeField] private bool canSpeedUp; // Có thể sử dụng kĩ năng tăng tốc chưa?
    [SerializeField] private bool isSpeedUp; // Có đang sử dụng kĩ năng tăng tốc hay không?
    //Protected variables

    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        playerController = transform.parent.Find("PlayerController").GetComponent<PlayerController>();
        tr = GetComponentInParent<TrailRenderer>();
        canSpeedUp = true;
        isSpeedUp = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        startSpeed = playerController.playerMovement.speedMovement;
    }

    // Update is called once per frame
    void Update()
    {
       /* SpeedUp();*/
    }

    // Thực hiện kĩ năng tăng tốc
    public void SpeedUp()
    {
        // Xác định hướng player di chuyển
        Vector2 dashDirection = playerController.playerMovement.movementDirection;
        if (/*Input.GetKeyDown(KeyCode.Space) && */canSpeedUp && !isSpeedUp)
        {
            playerController.playerMovement.speedMovement += speedUp;
            tr.emitting = true;
            canSpeedUp = false; 
            isSpeedUp = true;
            StartCoroutine(SpeedUpTime());

        }
    }

    // Thời gian thực hiện kĩ năng tăng tốc
    IEnumerator SpeedUpTime()
    {
        yield return new WaitForSeconds(speedUpTime);
        playerController.playerMovement.speedMovement -= speedUp;
        tr.emitting = false;
        StartCoroutine(SpeedUpCoolDown());
    }

    // Thời gian cooldown của kĩ năng tăng tốc
    IEnumerator SpeedUpCoolDown()
    {
        yield return new WaitForSeconds(speedUpCoolDown);
        canSpeedUp = true;
        isSpeedUp = false;
    }

    private void OnDisable()
    {
        playerController.playerMovement.speedMovement = startSpeed; 
        tr.emitting = false;
        canSpeedUp = true;
        isSpeedUp = false;
    }
}
