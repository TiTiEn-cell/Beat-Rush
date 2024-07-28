using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningZoneBlackHoleSpawnBlackHole : MonoBehaviour
{
    //Public variables
    //Private variables
    [SerializeField] private GameObject blackHolePrefab; 
    [SerializeField] private float spawnInterval = 2f; //Thời gian spawn
    [SerializeField] private bool hasSpawn; //Đã spawn chưa?
    private float spawnTimer;
    //Protected variables

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval && !hasSpawn)
        {
            SpawnBlackHole();
            spawnTimer = 0;
        }
    }

    void SpawnBlackHole()
    {
        Instantiate(blackHolePrefab, transform.parent.position, blackHolePrefab.transform.rotation);
        hasSpawn = true;
        Destroy(transform.parent.gameObject);
    }
}
