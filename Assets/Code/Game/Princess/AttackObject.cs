using System.Collections.Generic;
using UnityEngine;

public class AttackObject
{
    public Dictionary<ABulletSpawner, List<Vector2>> attacks { get; private set; }

    public void AddAttacks(ABulletSpawner spawner, List<Vector2> attacksList)
    {
        if(attacks.ContainsKey(spawner))
        {
            attacks[spawner] = attacksList;
            return;
        }
        attacks.Add(spawner, attacksList);
    }
}
