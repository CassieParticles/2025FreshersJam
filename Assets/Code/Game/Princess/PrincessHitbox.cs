using UnityEngine;

public class PrincessHitbox : MonoBehaviour
{
    private HealthComponent healthComponent;

    private void Awake()
    {
        healthComponent = GetComponentInParent<HealthComponent>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpitFlyProjectile projectile = collision.GetComponent<SpitFlyProjectile>();
        if (projectile)
        {
            healthComponent.TakeDamage(projectile.projectileDamage);

            //TODO: Replace this with destroy function
            Destroy(projectile.gameObject);
        }
    }
}
