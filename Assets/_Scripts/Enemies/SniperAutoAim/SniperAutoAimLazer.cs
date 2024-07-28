using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperAutoAimLazer : MonoBehaviour
{
    // Public variables
    public bool isAimPlayer; // Có đang aim player không?
    public bool isAimingComplete; // Đã hoàn thành quá trình nhắm chưa?
    public bool canShoot;
    public LineRenderer lineRenderer;

    // Private variables
    private PlayerController playerController;
    private Vector2 playerDirection;
    private Vector3 oldPosAim;
    private Vector3 newPosAim;
    [SerializeField] private float lazerRange = 10f; // Độ dài lazer
    [SerializeField] private float aimTime = 5f; // Thời gian aim player
    [SerializeField] private float timeToShoot = 1f;
    [SerializeField] private float followSpeed = 2f; // Tốc độ theo dõi

    private void Awake()
    {    
        lineRenderer = GetComponent<LineRenderer>();
        playerController = GameObject.Find("PlayerController").GetComponent<PlayerController>();
    }

    private void Start()
    {
        isAimPlayer = true;
        isAimingComplete = false;
        canShoot = false;
    }

    void Update()
    {
        if (isAimPlayer)
        {
            playerDirection = playerController.transform.position - transform.position; // Xác định hướng player
            GunAim(playerDirection);
            LazerAim(playerDirection);
        }
        else if (isAimingComplete)
        {
            Vector3 lazerDirection = lineRenderer.GetPosition(1) - transform.position; // Hướng hiện tại của lazer
            GunAim(lazerDirection);
        }
    }

    void GunAim(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Tính góc độ quay cho object từ Radian sang Degree
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle)); // Rotate theo góc độ đã tính
        // Rotate game object theo player hoặc hướng của lazer một cách mượt mà
        transform.parent.rotation = targetRotation;
    }

    void LazerAim(Vector3 direction)
    {
        lineRenderer.enabled = true; // Bắt đầu bắn laser
        lineRenderer.SetPosition(0, transform.position); // Set vị trí điểm bắt đầu bắn ra laser

        // Tính toán vị trí kết thúc của laser theo hướng hiện tại của direction
        Vector3 endPosition = transform.position + direction.normalized * lazerRange;
        oldPosAim = lineRenderer.GetPosition(1); // Vị trí hiện tại của laser

        // Sử dụng Vector3.Lerp để di chuyển mượt mà từ vị trí cũ đến vị trí mới
        newPosAim = Vector3.Lerp(oldPosAim, endPosition, followSpeed * Time.deltaTime);

        lineRenderer.SetPosition(1, newPosAim); // Set vị trí điểm kết thúc bắn laser

        StartCoroutine(StopAimPlayer());
    }

    IEnumerator StopAimPlayer()
    {
        yield return new WaitForSeconds(aimTime);
        isAimPlayer = false;
        isAimingComplete = true;
        StartCoroutine(ReadyToShoot());
    }

    IEnumerator ReadyToShoot()
    {
        yield return new WaitForSeconds(timeToShoot);
        canShoot = true;
    }

    private void OnEnable()
    {
        Start();
    }
}
