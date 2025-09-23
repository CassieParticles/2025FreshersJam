using UnityEngine;

public interface IBulletMovement
{
    public Vector2 direction { get; set; }
    public float speed { get; set; }

    public void InitBullet(Vector2 direction, float speed);
    public void ClearBullet();
}
