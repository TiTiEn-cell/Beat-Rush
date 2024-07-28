using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AutoSetActive : MonoBehaviour
{
    //Public variables
    //Private variables
    private float timer;
    private new Light2D light;
    //Protected variables

    private void Awake()
    {
        light = GetComponent<Light2D>();
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
        if (timer >= 1)
        {
            timer = 0;
            light.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Trigger exit");
        timer = 0;
        light.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger enter");
    }

}
