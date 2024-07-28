using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    //Public variables
    public Animator reviveAnim;
    //Private variables
    //Protected variables

    private void Awake()
    {
        reviveAnim = transform.parent.Find("Light").GetComponent<Animator>();
    }

    public void ReviveAnim()
    {
        reviveAnim.SetBool("IsRevive",true);
    }
}
