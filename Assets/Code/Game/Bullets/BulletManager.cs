using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] public GameObject Bullet;
    [SerializeField] private int initialBulletCount = 20;

    private List<IBulletMovement> bulletPool;


    private IBulletMovement AddNewBullet()
    {
        GameObject bullet = Instantiate(Bullet);
        bullet.transform.parent = transform;
        bullet.SetActive(false);

        return bullet.GetComponent<IBulletMovement>();
    }

    public void Awake()
    {
        bulletPool = new List<IBulletMovement>();

        //Instantiate bullets
        for(int i=0;i<initialBulletCount;++i)
        {
            bulletPool.Add(AddNewBullet());
        }
    }
}
