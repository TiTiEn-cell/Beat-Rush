using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleAnimator : MonoBehaviour
{
    //Public variables
    public float holdExtendTimer;
    public float holdExtendInterval = 3f;
    //Private variables
    private Animator animator;
    [SerializeField] private bool hasPlayAnimation;
    //Protected variables

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        holdExtendTimer += Time.deltaTime;
        if (holdExtendTimer > holdExtendInterval && !hasPlayAnimation)
        {
            animator.SetFloat("HoldExtend", 4);
            hasPlayAnimation = true;
        }
    }

    public void DestroyBlackHole()
    {
        Destroy(transform.parent.gameObject);
    }
}
