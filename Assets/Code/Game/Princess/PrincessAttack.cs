using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessAttack : MonoBehaviour
{
    private PrincessMovement movement;

    private KissSpawner kissSpawner;
    private CupcakeSpawner cupcakeSpawner;

    private List<AttackObject> attackObjects;
    
    private void Awake()
    {
        movement = GetComponent<PrincessMovement>();

        kissSpawner = GetComponentInChildren<KissSpawner>();
        cupcakeSpawner = GetComponentInChildren<CupcakeSpawner>();

        attackObjects = new List<AttackObject>();

        AddWallAttack();
        AddWaveAttack();
        AddDiagonalAttack();
    }

    private void Start()
    {
        StartCoroutine(RandomAttack());
    }

    private IEnumerator RandomAttack()
    {
        while(true)
        {
            int randomAttack = Random.Range(0, attackObjects.Count);

            AttackObject attack = attackObjects[randomAttack];

            attack.Attack(movement.side);

            yield return new WaitForSeconds(3 + attack.attackLength);
        }

    }

    private void AddWallAttack()
    {
        AttackObject attackObject = new AttackObject();

        attackObject.AddAttacks(kissSpawner, new AttackObject.AttackData[]
            {
                new AttackObject.AttackData(Vector2.zero,Vector2.right,5.0f,0.0f),
                new AttackObject.AttackData(Vector2.zero,Vector2.right,5.0f,0.3f),
                new AttackObject.AttackData(Vector2.zero,Vector2.right,5.0f,0.6f),
                new AttackObject.AttackData(Vector2.zero,Vector2.right,5.0f,0.9f),
                new AttackObject.AttackData(Vector2.zero,Vector2.right,5.0f,1.5f),
                new AttackObject.AttackData(Vector2.zero,Vector2.right,5.0f,1.8f),
                new AttackObject.AttackData(Vector2.zero,Vector2.right,5.0f,2.1f),
                new AttackObject.AttackData(Vector2.zero,Vector2.right,5.0f,2.4f),
                new AttackObject.AttackData(Vector2.zero,Vector2.right,5.0f,2.7f),
            });

        attackObject.AddAttacks(cupcakeSpawner, new AttackObject.AttackData[]
            {
                new AttackObject.AttackData(Vector2.zero,Vector2.right,5.0f,1.2f),
            });

        attackObjects.Add(attackObject);
    }

    private void AddWaveAttack()
    {
        //Spawner will need to move up and down
        AttackObject attackObject = new AttackObject();

        attackObject.AddAttacks(kissSpawner, new AttackObject.AttackData[]
            {
                new AttackObject.AttackData(new Vector2(0, 1),Vector2.right,5.0f,0.0f),
                new AttackObject.AttackData(new Vector2(0,-1),Vector2.right,5.0f,0.3f),
                new AttackObject.AttackData(new Vector2(0,-1),Vector2.right,5.0f,0.9f),
                new AttackObject.AttackData(new Vector2(0, 1),Vector2.right,5.0f,1.2f),
                new AttackObject.AttackData(new Vector2(0, 3),Vector2.right,5.0f,1.5f),
                new AttackObject.AttackData(new Vector2(0, 3),Vector2.right,5.0f,2.1f),
                new AttackObject.AttackData(new Vector2(0, 1),Vector2.right,5.0f,2.4f),
            });

        attackObject.AddAttacks(cupcakeSpawner, new AttackObject.AttackData[]
            {
                new AttackObject.AttackData(new Vector2(0,-3),Vector2.right,5.0f,0.6f),
                new AttackObject.AttackData(new Vector2(0, 5),Vector2.right,5.0f,1.8f),
            });

        attackObjects.Add(attackObject);
    }

    private void AddDiagonalAttack()
    {
        //Spawner will need to move up and down
        AttackObject attackObject = new AttackObject();

        float wideAngle = 45;
        float narrowAngle = 20;

        wideAngle *= Mathf.Deg2Rad;
        narrowAngle *= Mathf.Deg2Rad;

        attackObject.AddAttacks(kissSpawner, new AttackObject.AttackData[]
            {
                new AttackObject.AttackData(Vector2.zero,new Vector2(Mathf.Cos(wideAngle),Mathf.Sin(wideAngle)),5.0f,0.0f),
                new AttackObject.AttackData(Vector2.zero,new Vector2(Mathf.Cos(wideAngle),Mathf.Sin(wideAngle)),5.0f,0.2f),
                new AttackObject.AttackData(Vector2.zero,new Vector2(Mathf.Cos(wideAngle),Mathf.Sin(wideAngle)),5.0f,0.4f),
                new AttackObject.AttackData(Vector2.zero,new Vector2(Mathf.Cos(wideAngle),Mathf.Sin(wideAngle)),5.0f,0.6f),
                new AttackObject.AttackData(Vector2.zero,new Vector2(Mathf.Cos(wideAngle),Mathf.Sin(wideAngle)),5.0f,0.8f),

                new AttackObject.AttackData(Vector2.zero,new Vector2(Mathf.Cos(-wideAngle),Mathf.Sin(-wideAngle)),5.0f,1.0f),
                new AttackObject.AttackData(Vector2.zero,new Vector2(Mathf.Cos(-wideAngle),Mathf.Sin(-wideAngle)),5.0f,1.2f),
                new AttackObject.AttackData(Vector2.zero,new Vector2(Mathf.Cos(-wideAngle),Mathf.Sin(-wideAngle)),5.0f,1.4f),
                new AttackObject.AttackData(Vector2.zero,new Vector2(Mathf.Cos(-wideAngle),Mathf.Sin(-wideAngle)),5.0f,1.6f),
                new AttackObject.AttackData(Vector2.zero,new Vector2(Mathf.Cos(-wideAngle),Mathf.Sin(-wideAngle)),5.0f,1.8f),

                new AttackObject.AttackData(Vector2.zero,new Vector2(Mathf.Cos(narrowAngle),Mathf.Sin(narrowAngle)),5.0f,2.0f),
                new AttackObject.AttackData(Vector2.zero,new Vector2(Mathf.Cos(narrowAngle),Mathf.Sin(narrowAngle)),5.0f,2.2f),
                new AttackObject.AttackData(Vector2.zero,new Vector2(Mathf.Cos(narrowAngle),Mathf.Sin(narrowAngle)),5.0f,2.4f),
                new AttackObject.AttackData(Vector2.zero,new Vector2(Mathf.Cos(narrowAngle),Mathf.Sin(narrowAngle)),5.0f,2.6f),
                new AttackObject.AttackData(Vector2.zero,new Vector2(Mathf.Cos(narrowAngle),Mathf.Sin(narrowAngle)),5.0f,2.8f),

                new AttackObject.AttackData(Vector2.zero,new Vector2(Mathf.Cos(-narrowAngle),Mathf.Sin(-narrowAngle)),5.0f,3.0f),
                new AttackObject.AttackData(Vector2.zero,new Vector2(Mathf.Cos(-narrowAngle),Mathf.Sin(-narrowAngle)),5.0f,3.2f),
                new AttackObject.AttackData(Vector2.zero,new Vector2(Mathf.Cos(-narrowAngle),Mathf.Sin(-narrowAngle)),5.0f,3.4f),
                new AttackObject.AttackData(Vector2.zero,new Vector2(Mathf.Cos(-narrowAngle),Mathf.Sin(-narrowAngle)),5.0f,3.6f),
                new AttackObject.AttackData(Vector2.zero,new Vector2(Mathf.Cos(-narrowAngle),Mathf.Sin(-narrowAngle)),5.0f,3.8f),
            });

        attackObject.AddAttacks(cupcakeSpawner, new AttackObject.AttackData[]
            {
                new AttackObject.AttackData(Vector2.zero,new Vector2(Mathf.Cos(wideAngle),Mathf.Sin(wideAngle)),5.0f,1.0f),
                new AttackObject.AttackData(Vector2.zero,new Vector2(Mathf.Cos(-wideAngle),Mathf.Sin(-wideAngle)),5.0f,2.0f),
                new AttackObject.AttackData(Vector2.zero,new Vector2(Mathf.Cos(narrowAngle),Mathf.Sin(narrowAngle)),5.0f,3.0f),
                new AttackObject.AttackData(Vector2.zero,new Vector2(Mathf.Cos(-narrowAngle),Mathf.Sin(-narrowAngle)),5.0f,4.0f)
            });

        attackObjects.Add(attackObject);
    }


    private void FixedUpdate()
    {
        
    }
}
