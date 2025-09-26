using System.Collections.Generic;
using UnityEngine;

public class AttackObject
{
    public struct AttackData
    {
        public AttackData(Vector2 position, Vector2 direction, float speed)
        {
            this.position = position;
            this.direction = direction; 
            this.speed = speed; 
        }
        public Vector2 position;
        public Vector2 direction;
        public float speed;
    }

    public Dictionary<ABulletSpawner, AttackData[]> attacks { get; private set; }

    public AttackObject()
    {
        attacks = new Dictionary<ABulletSpawner, AttackData[]>();
    }

    public void AddAttacks(ABulletSpawner spawner, AttackData[] attacksList)
    {
        if(attacks.ContainsKey(spawner))
        {
            attacks[spawner] = attacksList;
            return;
        }
        attacks.Add(spawner, attacksList);
    }

    public void Attack(PrincessMovement.Side side)
    {
        foreach (ABulletSpawner spawner in attacks.Keys)
        {
            spawner.SpawnAttack(this, side);
        }
    }
}
