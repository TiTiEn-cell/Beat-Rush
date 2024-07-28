using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnCount
{
    public GameObject objSpawn;
    public Transform parentPool;
    public float spawnTime;
    public Vector2 spawnPosition;
    public Quaternion spawnRotation;
}

public class SpawnManager : MonoBehaviour
{
    //Public variables
    public List<SpawnCount> spawnCounts;
    public GameObject objSpawn;
    //Private variables
    private MusicManager musicManager;
    private int spawnIndex;
    private List<string> usedNames; // Sử dụng List để kiểm tra tên đã tồn tại

    private void Awake()
    {
        musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();
        usedNames = new List<string>();
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnIndex = 0;
        for (int i = 0; i < spawnCounts.Count; i++)
        {
            string nameObj = spawnCounts[i].objSpawn.name + "(" + spawnCounts[i].spawnPosition.x + ", " + spawnCounts[i].spawnPosition.y + ")";
            if (!usedNames.Contains(nameObj))
            {
                objSpawn = Instantiate(spawnCounts[i].objSpawn, spawnCounts[i].spawnPosition, spawnCounts[i].spawnRotation);
                objSpawn.SetActive(false);
                objSpawn.name = nameObj;
                objSpawn.transform.SetParent(spawnCounts[i].parentPool);
                usedNames.Add(nameObj); // Thêm tên vào List
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (spawnIndex < spawnCounts.Count && musicManager.GetMusicTime() >= spawnCounts[spawnIndex].spawnTime)
        {
            string nameObj = spawnCounts[spawnIndex].objSpawn.name + "(" + spawnCounts[spawnIndex].spawnPosition.x + ", " + spawnCounts[spawnIndex].spawnPosition.y + ")";
            foreach (Transform obj in spawnCounts[spawnIndex].parentPool)
            {
                if (nameObj == obj.name)
                {
                    obj.gameObject.SetActive(true);
                }
            }
            spawnIndex++;
        }
    }
}
