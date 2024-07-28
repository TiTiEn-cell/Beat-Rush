using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlackHolePull : MonoBehaviour
{
    //Public variables
    //Private variables
    [SerializeField] private float pull = 100f;
    private Rigidbody2D playerRb;
    //Protected variables

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 pullDirection = transform.position - playerRb.transform.position;
            playerRb.AddForce(pullDirection.normalized * pull);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerRb.velocity = Vector2.zero;
    }
}
