using UnityEngine;

public class FrogHealth : HealthComponent
{
    GameEvent loseEvent;


    [SerializeField] float iFrameDuration = 1.0f;
    private float iFrames;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (iFrames <= 0) {
            Debug.Log("FrogYeowch");
            if (collision.transform.GetComponent<ABulletMovement>() != null) {
                Debug.Log("FrogYeowch Bullet");
                ABulletMovement bullet = collision.transform.GetComponent<ABulletMovement>();
                if (bullet is IDamagePlayer damaging) {
                    Debug.Log("FrogYeowch Bullet Hurty");
                    TakeDamage(damaging.GetDamage());
                    iFrames = iFrameDuration;
                    bullet.ClearBullet();
                }
            }
        }
    }

    private void Update() {
        iFrames -= Time.deltaTime;
    }
}
