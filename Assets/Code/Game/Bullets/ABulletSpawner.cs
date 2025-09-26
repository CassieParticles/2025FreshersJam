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
            bulletManager.GetNewBullet((Vector2)transform.position + attackData.position, attackData.direction, attackData.speed);
        }
    }
}
