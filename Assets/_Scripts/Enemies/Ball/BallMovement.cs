using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    //Public variables
    //Private variables
    [SerializeField] private float speed;
    [SerializeField] private float timeUp;
    [SerializeField] private float timedown;
    [SerializeField] private bool goUp;
    private float timer;
    private float timerSecond;
    //Protected variables

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        timer = timeUp / 2;
        goUp = true;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer < timeUp && goUp)
        {
            goUp = true;
            transform.parent.Translate(Vector2.right * speed * Time.deltaTime, Space.Self);
            transform.parent.Translate(Vector2.up * speed * Time.deltaTime, Space.Self);
        }
        else
        {
            timer = 0f;
            goUp = false;
            timerSecond += Time.deltaTime;
            transform.parent.Translate(Vector2.right * speed * Time.deltaTime, Space.Self);
            transform.parent.Translate(Vector2.down * speed * Time.deltaTime, Space.Self);
        }

        if (timerSecond > timedown)
        {
            goUp = true;
            timerSecond = 0;
        }

    }
}
