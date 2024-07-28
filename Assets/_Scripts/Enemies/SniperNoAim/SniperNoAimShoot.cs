using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperNoAimShoot : MonoBehaviour
{
    //Public variables
    //Private variables
    [SerializeField] private GameObject bulletPrefab;
    private SniperNoAimController sniperNoAimController;
    private BulletPool bulletPool;
    //Protected variables

    private void Awake()
    {
        sniperNoAimController = transform.parent.Find("SniperNoAimController").GetComponent<SniperNoAimController>();
        bulletPool = GameObject.Find("BulletPools").GetComponent<BulletPool>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!sniperNoAimController.sniperNoAimLazer.canShoot) return;
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

        /*Instantiate(bulletPrefab, transform.position, rotation);
        sniperNoAimController.sniperNoAimLazer.lineRenderer.enabled = false;
        transform.parent.gameObject.SetActive(false);*/
        }
    }
