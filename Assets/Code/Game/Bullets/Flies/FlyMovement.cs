using UnityEngine;

public class FlyMovement : MonoBehaviour, IBulletMovement
{
    //Implement interface fields
    public Vector2 direction { get; set; }
    public float speed { get; set; }

    public void InitBullet(Vector2 direction, float speed)
    {
        this.direction = direction;
        this.speed = speed;

        gameObject.SetActive(true);
    }

    public void ClearBullet()
    {
        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        transform.position += speed * Time.fixedDeltaTime * (Vector3)direction;
    }
}

