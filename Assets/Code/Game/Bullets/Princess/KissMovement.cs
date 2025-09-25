using UnityEngine;

public class KissMovement : ABulletMovement, IDamagePlayer
{
    [SerializeField] private float kissDamage;
    public float GetDamage()
    {
        return kissDamage;
    }
}
