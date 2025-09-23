using UnityEngine;

public class FlyMovement : ABulletMovement
{
    public override void InitBullet(Vector2 position, Vector2 direction, float speed)
    {
        transform.position = position; 
        this.direction = direction;
        this.speed = speed;

        gameObject.SetActive(true);
    }

    public override void ClearBullet()
    {
        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        transform.position += speed * Time.fixedDeltaTime * (Vector3)direction;
    }
}

