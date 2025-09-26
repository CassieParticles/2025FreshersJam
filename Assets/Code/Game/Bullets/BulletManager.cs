using NUnit.Framework.Constraints;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] public GameObject Bullet;
    [SerializeField] private GameObject bulletPoolPrefab;

    [SerializeField] private int initialBulletCount = 20;

    protected BulletPool bulletPoolObj;
    private List<GameObject> bulletPool;

    private GameObject AddNewBullet()
    {
        GameObject bullet = Instantiate(Bullet);
        bullet.transform.parent = bulletPoolObj.transform;
        bullet.SetActive(false);

        return bullet;
    }

    public void Awake()
    {
        bulletPool = new List<GameObject>();

        //Set up bullet pool
        bulletPoolObj = FindAnyObjectByType<BulletPool>();
        if (!bulletPoolObj)
        {
            bulletPoolObj = Instantiate(bulletPoolPrefab).GetComponent<BulletPool>();
        }

        //Instantiate bullets
        for (int i=0;i<initialBulletCount;++i)
        {
            bulletPool.Add(AddNewBullet());
        }
    }

    private IEnumerator DelaySpawning(Vector2 position, Vector2 direction, float speed, float delay)
    {
        yield return new WaitForSeconds(delay);
        GetNewBullet(position, direction, speed);
    }

    public void GetNewBulletDelay(Vector2 position, Vector2 direction, float speed, float delay)
    {
        StartCoroutine(DelaySpawning(position,direction,speed, delay));
    }

    public ABulletMovement GetNewBullet(Vector2 position, Vector2 direction, float speed)
    {
        foreach(GameObject bullet in bulletPool)
        {
            if(!bullet.activeSelf)
            {
                ABulletMovement bulletMovement = bullet.GetComponent<ABulletMovement>();
                bulletMovement.InitBullet(position, direction, speed);
                return bulletMovement;
            }
        }
        //Create a new bullet in the pool
        GameObject newBullet = AddNewBullet();
        bulletPool.Add(newBullet);
        ABulletMovement newBulletMovement = newBullet.GetComponent<ABulletMovement>();
        newBulletMovement.InitBullet(position, direction, speed);

        return newBulletMovement;
    }
}
