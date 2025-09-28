using System.Collections.Generic;
using UnityEngine;

public class AttackObject
{
    public struct AttackData
    {
        public AttackData(Vector2 position, Vector2 direction, float speed, float delay)
        {
            this.position = position;
            this.direction = direction; 
            this.speed = speed;
            this.delay = delay;
        }
        public Vector2 position;
        public Vector2 direction;
        public float speed;
        public float delay;
    }


    public Dictionary<ABulletSpawner, AttackData[]> attacks { get; private set; }
    public float attackLength { get; private set; }

    public AttackObject()
    {
        attacks = new Dictionary<ABulletSpawner, AttackData[]>();
        attackLength = 0;
    }

    public void AddAttacks(ABulletSpawner spawner, AttackData[] attacksList)
    {
        if(attacks.ContainsKey(spawner))
        {
            attacks[spawner] = attacksList;
            return;
        }
        attacks.Add(spawner, attacksList);

        foreach(AttackData data in attacksList)
        {
            attackLength = Mathf.Max(attackLength, data.delay);
        }
    }

    public void Attack(PrincessMovement.Side side)
    {
        foreach (ABulletSpawner spawner in attacks.Keys)
        {
            spawner.SpawnAttack(this, side);
        }
    }
}
