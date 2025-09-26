using System.Collections.Generic;
using UnityEngine;
using static AttackObject;

public abstract class ABulletSpawner : MonoBehaviour
{

    protected BulletManager bulletManager;

    private void Awake()
    {
        bulletManager = GetComponent<BulletManager>();


    }

    public void SpawnAttack(AttackObject attackObject, PrincessMovement.Side side)
    {
        AttackData[] attacks = attackObject.attacks[this];

        foreach (AttackData attackData in attacks)
        {
            //Flip attacks coming from right side
            Vector2 direction = attackData.direction;
            if (side == PrincessMovement.Side.Right)
            {
                direction.x *= -1;
            }
            bulletManager.GetNewBullet((Vector2)transform.position + attackData.position, direction, attackData.speed);
        }
    }
}
