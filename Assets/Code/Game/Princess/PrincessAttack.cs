using UnityEngine;

public class PrincessAttack : MonoBehaviour
{
    private KissSpawner kissSpawner;
    private CupcakeSpawner cupcakeSpawner;

    private AttackObject attack;
    
    private void Awake()
    {
        kissSpawner = GetComponentInChildren<KissSpawner>();
        cupcakeSpawner = GetComponentInChildren<CupcakeSpawner>();

        

        attack = new AttackObject();
        attack.AddAttacks(kissSpawner, new AttackObject.AttackData[5]
            {
                new ( new Vector2(0,0),Vector2.right,3.0f),
                new ( new Vector2(0,1),Vector2.right,3.0f),
                new ( new Vector2(0,2),Vector2.right,3.0f),
                new ( new Vector2(0,3),Vector2.right,3.0f),
                new ( new Vector2(0,4),Vector2.right,3.0f)
            });
    }

    private void FixedUpdate()
    {
        attack.Attack();
    }
}
