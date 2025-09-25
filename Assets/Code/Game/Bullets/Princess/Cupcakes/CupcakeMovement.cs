using UnityEngine;

public class CupcakeMovement : ABulletMovement, IEdible, IDamagePlayer
{
    [SerializeField] private float damage;
    public void Eaten()
    {
        ClearBullet();
    }

    public float GetDamage()
    {
        return damage;
    }

    public new void FixedUpdate()
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
