using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Hole1_Y_LightWarning : MonoBehaviour
{
    //Public variables
    //Private variables
    [SerializeField] private float timeInterval;
    private float timer;

    //Protected variables
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeInterval)
        {
            transform.parent.gameObject.SetActive(false);
        }
        else
        {
            transform.parent.gameObject.SetActive(true);
        }
    }

    private void OnEnable()
    {
        Start();
    }
}
