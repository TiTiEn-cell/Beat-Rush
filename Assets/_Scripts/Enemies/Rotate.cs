using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    //Public variables
    //Private variables
    [SerializeField] private float speedRotate;
    private Transform rotateSprite;
    //Protected variables

    // Start is called before the first frame update
    void Start()
    {
        rotateSprite = transform.parent.Find("Sprite");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.rotation == Quaternion.Euler(0,0,0))
        {
        rotateSprite.Rotate(Vector3.back, speedRotate * Time.deltaTime);
        }
        else
        {
        rotateSprite.Rotate(Vector3.forward, speedRotate * Time.deltaTime);
        }
    }
}
