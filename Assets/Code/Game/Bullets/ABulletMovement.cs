using UnityEngine;

public abstract class ABulletMovement:MonoBehaviour
{
    public Vector2 direction;
    public float speed;

    public virtual void InitBullet(Vector2 position, Vector2 direction, float speed)
    {
        transform.position = position;
        this.direction = direction;
        this.speed = speed;

        gameObject.SetActive(true);
    }
    public virtual void ClearBullet()
    {
        gameObject.SetActive(false);
    }

    public void FixedUpdate()
    {
        transform.position += speed * Time.fixedDeltaTime * (Vector3)direction;
    }
}
