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
    }
}

