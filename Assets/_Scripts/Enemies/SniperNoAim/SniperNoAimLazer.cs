using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SniperNoAimLazer : MonoBehaviour
{
    // Public variables
    public bool canShoot;
    public LineRenderer lineRenderer;
    // Private variables
    [SerializeField] private float lazerRange = 50f;
    [SerializeField] private float timeShoot = 2f;

    // Protected variables

    private void Awake()
    {
        
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        canShoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        Lazer();
    }

    void Lazer()
    {
        lineRenderer.enabled = true;
        // Vị trí bắt đầu của tia laser là vị trí của đối tượng cha
        lineRenderer.SetPosition(0, transform.parent.position);

        // Vị trí kết thúc của tia laser theo hướng x-axis của đối tượng cha
        Vector3 endPosition = transform.parent.position + transform.parent.right * lazerRange;
        lineRenderer.SetPosition(1, endPosition);
        StartCoroutine(ReadyToShoot());
    }

    IEnumerator ReadyToShoot()
    {
        yield return new WaitForSeconds(timeShoot);
        canShoot = true;
    }

    private void OnEnable()
    {
        Start();
    }
}
