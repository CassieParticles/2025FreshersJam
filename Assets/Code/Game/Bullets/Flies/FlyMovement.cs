using System.Collections;
using UnityEngine;

public class FlyMovement : ABulletMovement, IEdible
{
    [SerializeField] private float angleRange = 15;
    [SerializeField] private float changeDirectionFreq = 2;

    [SerializeField, Range(0, 15)] private int curveOrder = 1;

    private float time;

    private float initialAngle;
    private float previousAngle;
    private float nextAngle;

    public void Eaten()
    {
        ClearBullet();
    }

    public override void InitBullet(Vector2 position, Vector2 direction, float speed)
    {
        base.InitBullet(position, direction, speed);

        initialAngle = Mathf.Atan2(direction.y, direction.x);
        previousAngle = initialAngle;

        ChangeDirection();
    }

    public override void ClearBullet()
    {
        base.ClearBullet();
    }

    private void ChangeDirection()
    {
        float randomOffset = Random.Range(-angleRange * Mathf.Deg2Rad, angleRange * Mathf.Deg2Rad);

        nextAngle = initialAngle + randomOffset;
    }


    private void setInterpAngle(float prevAngle, float nextAngle, float time)
    {
        float timeNorm = time / changeDirectionFreq;
        float offset = Mathf.Pow(timeNorm, curveOrder);

        float angle = prevAngle + (nextAngle - prevAngle) * offset;

        direction.x = Mathf.Cos(angle);
        direction.y = Mathf.Sin(angle);
    }

    public new void FixedUpdate()
    {
        base.FixedUpdate();

        Vector2 screenPos = Camera.main.WorldToViewportPoint(transform.position);

        time += Time.fixedDeltaTime;
        setInterpAngle(previousAngle, nextAngle, time);
        
        if(time > changeDirectionFreq)
        {
            time = 0;
            previousAngle = nextAngle;

            ChangeDirection();
        }
        

        //Bullet is off screen
        if(screenPos.x < 0 || screenPos.x > 1 || screenPos.y < 0 || screenPos.y > 1)
        {
            ClearBullet();
        }
    }


}

