using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private GameEvent DeathEvent;

    public float health { get; private set; }

    private void Awake()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health < 0)
        {
            DeathEvent?.Notify();
        }
    }
}
