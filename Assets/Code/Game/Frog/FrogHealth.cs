using UnityEngine;

public class FrogHealth : HealthComponent
{


    [SerializeField] float iFrameDuration = 1.0f;
    private float iFrames;

    SpriteRenderer spr;

    private void Awake() {
        spr = GetComponent<SpriteRenderer>();
    }

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
                    spr.color = new Color(0.7f, 0.7f, 0.7f);
                    bullet.ClearBullet();
                }
            }
        }
    }

    private void Update() {
        iFrames -= Time.deltaTime;

        if (iFrames <= 0) {
            spr.color = new Color(1f, 1f, 1f);
        }
    }
}
