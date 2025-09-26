using UnityEngine;

public class FrogHealth : HealthComponent
{
    GameEvent loseEvent;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.GetComponent<ABulletMovement>() != null) {
            ABulletMovement bullet = collision.transform.GetComponent<ABulletMovement>();
            if (bullet is IDamagePlayer) {
                TakeDamage(((IDamagePlayer)bullet).GetDamage());
            }
        }
    }
}
