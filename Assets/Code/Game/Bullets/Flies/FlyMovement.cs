using UnityEngine;

public class FlyMovement : ABulletMovement
{
    public override void InitBullet(Vector2 position, Vector2 direction, float speed)
    {
        base.InitBullet(position, direction, speed);
    }

    public override void ClearBullet()
    {
        base.ClearBullet();
    }

    public new void FixedUpdate()
    {
        base.FixedUpdate();

        Vector2 screenPos = Camera.main.WorldToViewportPoint(transform.position);

        //Bullet is off screen
        if(screenPos.x < 0 || screenPos.x > 1 || screenPos.y < 0 || screenPos.y > 1)
        {
            ClearBullet();
        }
    }
}

