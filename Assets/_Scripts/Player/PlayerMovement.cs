using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    //Public variables
    public Joystick joystick;
    public float speedMovement = 5f; // Tốc độ di chuyển mặc định
    public Vector2 movementDirection; // Hướng di chuyển
    //Private variables
    private float horizontalInput;
    private float verticalInput;
    private float minX, maxX, minY, maxY;


    //Protected variables

    private void Awake()
    {
        // Lấy biên của camera tại thời điểm bắt đầu
        Vector2 bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        Vector2 topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        minX = bottomLeft.x;
        maxX = topRight.x;
        minY = bottomLeft.y;
        maxY = topRight.y;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }


    // Thực hiện việc di chuyển của người chơi
    void Movement()
    {
        horizontalInput = joystick.Horizontal; /*Input.GetAxisRaw("Horizontal");*/
        verticalInput = joystick.Vertical; /*Input.GetAxisRaw("Vertical");*/

        movementDirection = new Vector2(horizontalInput, verticalInput);

        //Chuẩn hóa lại vector để đảm bảo tốc độ di chuyển nhất quán
        if (movementDirection.magnitude > 1)
        {
            movementDirection.Normalize();
        }

        //Vị trí mới khi Player di chuyển
        Vector2 newPosition = (Vector2)transform.parent.position + movementDirection * speedMovement * Time.deltaTime;

        //Giới hạn player di chuyển ra khỏi cam
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        //Di chuyển player
        transform.parent.position = newPosition;
    }


}
