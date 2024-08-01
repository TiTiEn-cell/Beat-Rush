using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDueToAnimation : MonoBehaviour
{
    //Public variables
    //Private variables
    //Protected variables

    public void DestroyObj()
    {
        Destroy(transform.parent.gameObject);
    }

}
