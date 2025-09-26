using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BulletManager))]
public class FlySpawner : ABulletSpawner
{
    [SerializeField] private float flySpawnFreq = 2;
    [SerializeField] private float flySpeed = 3;

    Coroutine flySpawnCoroutine;


    private Vector2 CalculateSpawningLocation(Vector2 direction)
    {
        float upDot = Vector2.Dot(direction, Vector2.up);
        float rightDot = Vector2.Dot(direction, Vector2.right);

        float randomOffset = Random.Range(0.0f, 1.0f);

        if(Mathf.Abs(upDot) > Mathf.Abs(rightDot))
        {
            if(upDot < 0)
            {
                //Top
                return Camera.main.ViewportToWorldPoint(new Vector2(randomOffset,1));
            }
            else
            {
                //Bottom
                return Camera.main.ViewportToWorldPoint(new Vector2(randomOffset, 0));
            }
        }
        else
        {
            if(rightDot < 0)
            {
                //Right
                return Camera.main.ViewportToWorldPoint(new Vector2(1, randomOffset));
            }
            else
            {
                //Left
                return Camera.main.ViewportToWorldPoint(new Vector2(0, randomOffset));
            }
        }
    }

    private IEnumerator SpawnFly()
    {
        while(true)
        {
            yield return new WaitForSeconds(flySpawnFreq);

            float randomAngle = Random.Range(0, Mathf.PI * 2);
            Vector2 randomVector = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));

            bulletManager.GetNewBullet(CalculateSpawningLocation(randomVector), randomVector,flySpeed);
        }
    }

    private void OnEnable()
    {
        flySpawnCoroutine  = StartCoroutine(SpawnFly());
    }

    private void OnDisable()
    {
        if (flySpawnCoroutine != null)
        {
            StopCoroutine(flySpawnCoroutine);
            flySpawnCoroutine = null;
        }
    }
}
