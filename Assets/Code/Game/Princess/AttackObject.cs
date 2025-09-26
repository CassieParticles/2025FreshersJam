using System.Collections.Generic;
using UnityEngine;

public class AttackObject
{
    public struct AttackData
    {
        public Vector2 position;
        public Vector2 direction;
        public float speed;
    }

    public Dictionary<ABulletSpawner, AttackData[]> attacks { get; private set; }

    public void AddAttacks(ABulletSpawner spawner, AttackData[] attacksList)
    {
        if(attacks.ContainsKey(spawner))
        {
            attacks[spawner] = attacksList;
            return;
        }
        attacks.Add(spawner, attacksList);
    }
}
