using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveByDistance : MonoBehaviour
{
    //Public variables
    public float distance;
    //Private variables
    [SerializeField] private float distanceBound = 30f;
    [SerializeField] private Vector3 startPos;
    private GameObject Cam;
    //Protected variables

    private void Awake()
    {
        Cam = GameObject.Find("Main Camera");
    }
    // Start is called before the first frame update
    void Start()
    {
        distance = 30f;
    }   

    // Update is called once per frame
    void Update()
    {
        SetActiveByDis();
    }

    void SetActiveByDis()
    {
        distance = Vector2.Distance(transform.parent.position, Cam.transform.position);
        if (distance >= distanceBound)
        {
        transform.parent.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {

        startPos = transform.parent.position;
    }

    private void OnDisable()
    {
        transform.parent.position = startPos;
    }

}
