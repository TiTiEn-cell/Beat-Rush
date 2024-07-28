using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    //Public variables
    //Private variables
    [SerializeField] private float speedFly = 10f;
    //Protected variables

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.parent.Translate(Vector2.up * speedFly * Time.deltaTime);
    }
}
