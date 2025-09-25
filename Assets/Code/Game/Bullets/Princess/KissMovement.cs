using UnityEngine;

public class KissMovement : ABulletMovement, IDamagePlayer
{
    [SerializeField] private float kissDamage;
    public float GetDamage()
    {
        return kissDamage;
    }

    private new void FixedUpdate()
    {
        base.FixedUpdate();
        Vector2 screenPos = Camera.main.WorldToViewportPoint(transform.position);

        //Bullet is off screen
        if (screenPos.x < 0 || screenPos.x > 1 || screenPos.y < 0 || screenPos.y > 1)
        {
            ClearBullet();
        }
    }
}
