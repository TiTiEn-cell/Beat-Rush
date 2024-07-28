using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAcrossTheWall : MonoBehaviour
{
    //Public variables
    public bool isAcrossTheWall; // Có đang sử dụng kĩ năng đi xuyên tường không?
    //Private variables
    private CircleCollider2D circleCollider2D;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    [SerializeField] private float acrossTheWallTime = 1.5f; // Thời gian kéo dài kĩ năng đi xuyên tường
    [SerializeField] private float acrossTheWallCoolDown = 3f; // Thời gian cooldown kĩ năng đi xuyên tường
    [SerializeField] private float transparencyAlpha = 0.5f; // Độ mờ mong muốn (0.0 - hoàn toàn trong suốt, 1.0 - hoàn toàn không trong suốt)
    [SerializeField] private bool canAcrossTheWall; // Có thể sử dụng kĩ năng đi xuyên tường chưa?
    //Protected variables

    private void Awake()
    {
        canAcrossTheWall = true;
        circleCollider2D = transform.parent.Find("PlayerCollider").GetComponent<CircleCollider2D>();
        spriteRenderer = transform.parent.Find("PlayerSprite").GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AcrossTheWall();
    }

    // Thực hiện kĩ năng đi xuyên tường
    private void AcrossTheWall()
    {
        if (Input.GetKeyDown(KeyCode.Z) && canAcrossTheWall && !isAcrossTheWall)
        {
            circleCollider2D.enabled = false;
            Color newColor = originalColor; 
            newColor.a = transparencyAlpha;
            spriteRenderer.color = newColor; // Set lại màu mới khi sử dụng kĩ năng đi xuyên tường
            canAcrossTheWall = false;
            isAcrossTheWall = true;
            StartCoroutine(AcrossTheWallTime());
        }
    }

    // Thời gian thực hiện kĩ năng đi xuyên tường
    IEnumerator AcrossTheWallTime()
    {
        yield return new WaitForSeconds(acrossTheWallTime);
        circleCollider2D.enabled = true; 
        spriteRenderer.color = originalColor; // Set lại màu mặc định khi kĩ năng đi xuyên tường kết thúc
        isAcrossTheWall = false;
        StartCoroutine(AcrossTheWallCoolDown());
    }

    // Thời gian cooldown kĩ năng đi xuyên tường
    IEnumerator AcrossTheWallCoolDown()
    {
        yield return new WaitForSeconds(acrossTheWallCoolDown);
        canAcrossTheWall = true;
    }
}
