using UnityEngine;

public abstract class ABulletMovement:MonoBehaviour
{
    public Vector2 direction { get; set; }
    public float speed { get; set; }

    public abstract void InitBullet(Vector2 position, Vector2 direction, float speed);
    public abstract void ClearBullet();
}
