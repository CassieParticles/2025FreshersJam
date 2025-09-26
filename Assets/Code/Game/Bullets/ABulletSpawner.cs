using UnityEngine;

public abstract class ABulletSpawner : MonoBehaviour
{
    protected BulletManager bulletManager;

    private void Awake()
    {
        bulletManager = GetComponent<BulletManager>();
    }
}
