using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] public GameObject Bullet;
    [SerializeField] private int initialBulletCount = 20;

    private List<GameObject> bulletPool;

    private GameObject AddNewBullet()
    {
        GameObject bullet = Instantiate(Bullet);
        bullet.transform.parent = transform;
        bullet.SetActive(false);

        return bullet;
    }

    public void Awake()
    {
        bulletPool = new List<GameObject>();

        //Instantiate bullets
        for(int i=0;i<initialBulletCount;++i)
        {
            bulletPool.Add(AddNewBullet());
        }
    }
}
