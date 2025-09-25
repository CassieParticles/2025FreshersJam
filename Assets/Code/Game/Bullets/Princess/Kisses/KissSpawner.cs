using UnityEngine;

public class KissSpawner : MonoBehaviour
{
    private BulletManager bulletManager;

    private void Awake()
    {
        bulletManager = GetComponent<BulletManager>();
    }

    private void FixedUpdate()
    {
        bulletManager.GetNewBullet(transform.position, Vector2.right, 3);
    }
}
