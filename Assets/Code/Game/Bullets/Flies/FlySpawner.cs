using UnityEngine;

[RequireComponent(typeof(BulletManager))]
public class FlySpawner : MonoBehaviour
{
    BulletManager bulletManager;

    private void Awake()
    {
        bulletManager = GetComponent<BulletManager>();
    }

    private void FixedUpdate()
    {
        Debug.Log("Fly upon ye");
        float angle = Random.Range(0, 6.28f);
        bulletManager.GetNewBullet(Vector2.zero, new Vector2(Mathf.Cos(angle),Mathf.Sin(angle)), 3);
    }
}
