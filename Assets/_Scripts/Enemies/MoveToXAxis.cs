using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToXAxis : MonoBehaviour
{
    //Public variables
    //Private variables
    [SerializeField] private float speedMovement = 2f;
    //Protected variables

    // Start is called before the first frame update    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.parent.Translate(Vector2.right * speedMovement * Time.deltaTime);
    }
}
