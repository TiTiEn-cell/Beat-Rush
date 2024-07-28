using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpSpace : MonoBehaviour
{
    //Public variables
    //Private variables
    private Rigidbody2D rb;
    private PlayerController playerController;
    [SerializeField] private float jumpSpaceDistance; // Khoảng cách bước nhảy không gian
    [SerializeField] private float jumpSpaceCoolDown; // Thời gian cooldown kĩ năng bước nhảy không gian
    [SerializeField] private bool canJumpSpace; // Có thể thực hiện kĩ năng bước nhảy không gian không?
    Vector2 jumpSpaceDirection; // Hướng sử dụng kĩ năng bước nhảy không gian
    //Protected variables


    private void Awake()
    {
        canJumpSpace = true;
        rb = GetComponentInParent<Rigidbody2D>();
        playerController = transform.parent.Find("PlayerController").GetComponent<PlayerController>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        JumpSpace();

    }
    void JumpSpace()
    {
        jumpSpaceDirection = playerController.playerMovement.movementDirection;
        if (Input.GetKeyDown(KeyCode.X) && canJumpSpace && jumpSpaceDirection.magnitude >= 0.1f)
        {
            Vector2 currentPos = transform.parent.position;
            currentPos += jumpSpaceDirection * jumpSpaceDistance;
            transform.parent.position = currentPos;
            canJumpSpace = false;
            StartCoroutine(JumpSpaceCoolDown());
        }

        //Thời gian cooldown kĩ năng bước nhảy không gian
        IEnumerator JumpSpaceCoolDown()
        {
            yield return new WaitForSeconds(jumpSpaceCoolDown);
            canJumpSpace = true;
        }
    }
}