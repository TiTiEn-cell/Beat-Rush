using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperAutoAimShoot : MonoBehaviour
{
    //Public variables
    //Private variables
    [SerializeField] private GameObject bulletPrefab;
    private SniperAutoAimController sniperAutoAimController;
    private BulletPool bulletPool;
    //Protected variables

    private void Awake()
    {
        sniperAutoAimController = transform.parent.Find("SniperAutoAimController").GetComponent<SniperAutoAimController>();
        bulletPool = GameObject.Find("BulletPools").GetComponent<BulletPool>();
    }

    // Start is called before the first frame update
    void Start()
    {
        /*hasShot = false;*/
    }

    // Update is called once per frame
    void Update()
    {
        if (!sniperAutoAimController.sniperAutoAimLazer.canShoot) return;
        Shoot();
    }

    void Shoot()
    {
        Quaternion rotation = transform.parent.rotation * Quaternion.Euler(0, 0, -90);
        GameObject bullet = bulletPool.GetBulletPools();
        if (bullet != null)
        {
            bullet.gameObject.SetActive(true);
            bullet.transform.rotation = rotation;
            bullet.transform.position = this.transform.position;
            transform.parent.gameObject.SetActive(false);
        }
    }
}
