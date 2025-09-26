using UnityEngine;

public class PrincessAttack : MonoBehaviour
{
    private PrincessMovement movement;

    private KissSpawner kissSpawner;
    private CupcakeSpawner cupcakeSpawner;

    private AttackObject attack;
    
    private void Awake()
    {
        movement = GetComponent<PrincessMovement>();

        kissSpawner = GetComponentInChildren<KissSpawner>();
        cupcakeSpawner = GetComponentInChildren<CupcakeSpawner>();

        attack = new AttackObject();
        attack.AddAttacks(kissSpawner, new AttackObject.AttackData[]
            {
                new ( new Vector2(0,0),Vector2.right,3.0f, 0.0f),
                new ( new Vector2(0,1),Vector2.right,3.0f, 0.0f),
                new ( new Vector2(0,3),Vector2.right,3.0f, 0.0f),
                new ( new Vector2(0,4),Vector2.right,3.0f, 0.0f)
            });

        attack.AddAttacks(cupcakeSpawner, new AttackObject.AttackData[]
            {
                new (new Vector2(0,2),Vector2.right, 3.0f, 0.0f)
            });
    }

    private void FixedUpdate()
    {
        attack.Attack(movement.side);
    }
}
