using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenceTransition : MonoBehaviour
{
    //Public variables
    public static ScenceTransition instance;
    //Private variables
    [SerializeField] private Animator animator;
    public GraphicRaycaster raycaster;
    //Protected variables

    private void Awake()
    {
        animator = GetComponent<Animator>();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(animator);
        }
        else
        {
            Destroy(gameObject);
        }
        raycaster = GetComponentInChildren<GraphicRaycaster>();


    }

    private void Start()
    {
        animator.SetTrigger("End");
        raycaster.enabled = false;
    }

    public void PlayTransition()
    {
        raycaster.enabled = true;
        animator.SetTrigger("Start");
    }

    public void EndTransition()
    {
        raycaster.enabled=false;
        animator.SetTrigger("End");
    }
}
