using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    //Public variables
    //Private variables
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int bulletCount;
    [SerializeField] private List<GameObject> bulletPools = new List<GameObject>();
    //Protected variables

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= bulletCount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bullet.transform.parent = transform;
            bulletPools.Add(bullet);
        }
    }

    public GameObject GetBulletPools()
    {
        for (int i = 0; i <= bulletPools.Count; i++)
        {
            if (!bulletPools[i].activeInHierarchy)
            {
            return bulletPools[i];
            }
        }
        return null;
    }
}
