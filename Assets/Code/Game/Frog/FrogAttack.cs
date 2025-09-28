using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Mathematics;

public class FrogAttack : MonoBehaviour
{
    //Input System Files
    InputActionAsset inputActions;

    private InputAction attackAction;
    private InputAction aimAction; //For controller support if we need it down the line
    //

    //Shorthands for used components
    private Rigidbody2D rb;
    private GameObject tongueBase;
    private GameObject tongueTip;
    private GameObject tongueWhole;
    //

    //Serialized Attributes, this is all the attributes available to change in the Inspector
    [SerializeField][Tooltip("The max range of the tongue in world units, you can imagine it as how far the frog can move in 1 second with a speed of the same value")] 
    private float tongueRange = 6;

    [SerializeField][Tooltip("How long the tongue is out for when using the tongue attack")]
    private float tongueDuration = 0.2f;

    [SerializeField][Tooltip("How long you need to wait before you can tongue again after the tongue is back")] 
    private float attackCooldown = 0.3f;

    [SerializeField][Tooltip("The speed of the fly when being spat out")]
    private float flyProjectileSpeed = 8;

    [SerializeField][Tooltip("The damage the fly deals to enemies when being spat out")]
    private int flyProjectileDamage = 2;

    [SerializeField]
    private GameObject flyProjectilePrefab;
    //

    //State Variables
    private int heldFlies;
    private float currentCooldown;

    Vector2 attackVectorGizmo;

    List<RaycastHit2D> tongueRay;
    //

    //Enable and Disable when necessary
    //private void OnEnable() {
    //    inputActions.FindActionMap("Player").Enable();
    //}
    //private void OnDisable() {
    //    inputActions.FindActionMap("Player").Disable();
    //}
    //

    //Set up variables and pointers
    private void Awake() {
        attackAction = InputSystem.actions.FindAction("Attack");

        rb = GetComponent<Rigidbody2D>();

        tongueWhole = transform.GetChild(0).gameObject;
        tongueBase = tongueWhole.transform.GetChild(0).gameObject;
        tongueTip = tongueWhole.transform.GetChild(1).gameObject;

        tongueRay = new List<RaycastHit2D>();
    }

    //HandleInputs
    private void Update() {
        //This is where aiming on controller would go
        currentCooldown -= Time.deltaTime;

        if (attackAction.WasPressedThisFrame() && currentCooldown <= 0) {

            if (heldFlies <= 0) {
                TongueAttack();
            
            } else {
                SpitAttack();
            }
            currentCooldown = attackCooldown;
        }
    }

    private void FixedUpdate() {
        
    }

    private void TongueAttack() {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 attackVector = (mousePos - rb.position);
        float rangedDistance = Mathf.Min((attackVector.normalized * tongueRange).magnitude, attackVector.magnitude);
        attackVectorGizmo = attackVector.normalized * rangedDistance;



        tongueWhole.transform.up = attackVector;
        //tongueTip.transform.up = attackVector;



        tongueRay = new List<RaycastHit2D>();
        tongueRay.AddRange(Physics2D.RaycastAll(rb.position, attackVector, rangedDistance, LayerMask.NameToLayer("3")));

        StartCoroutine(TongueAnimation(rangedDistance));

    }

    public IEnumerator TongueAnimation(float dist) {

        float timer = 0;

        tongueWhole.SetActive(true); //Reveal the tongue and prepare for tongue action

        //What Im doing here is taking a sine function (since they tend to stay for a moment at the height, which is what we want for a tongue)
        //And then cut off the lower half of it, and offsetting it, so that it starts in the middle of going up, and ends in the middle of going down

        float timeUnit = Mathf.PI / 6; //Units of time the function uses

        while (timer < tongueDuration) {
            float percentage = timer / tongueDuration; //Determine how far into the animation we are
            float sinePos = (percentage * 4 * timeUnit) + timeUnit; //Use 16% to 83% of a full sine wave, as that starts and ends it at exactly half the top height
            float finalCurve = (Mathf.Sin(sinePos) * 2) - 1; //Make it so the curve starts and ends at 0 and peaks at 1, despite not using the full sine wave

            float tongueStretch = Mathf.Lerp(0, dist, finalCurve) * 2f; //Lerp using the sine function
            tongueBase.transform.localScale = new Vector3(0.5f, tongueStretch, 0.5f); //Set the size of the tongue
            tongueTip.transform.localPosition = new Vector3(0, tongueStretch * 0.5f, 0); //And the position of the tip
            yield return new WaitForFixedUpdate();
            timer += Time.deltaTime; //Add time to the timer

            if (timer > tongueDuration / 2) {
                foreach (RaycastHit2D hit in tongueRay) { //Finds everything that hit the tongue
                    if (hit) {
                        //Debug.Log("Hit");
                        if (hit.transform.GetComponent<ABulletMovement>() != null) {
                            //Debug.Log("Is Bullet");
                            ABulletMovement bullet = hit.transform.GetComponent<ABulletMovement>(); //See if the hit is a bullet
                            if (bullet is IEdible edible) {
                                //Debug.Log("Eating");
                                edible.Eaten(); //Eat it if it is edible
                                heldFlies = 1;
                            }
                        } 
                    }
                }
            }
        }
        

        tongueWhole.SetActive(false); //Hide the tongue again
    }

    private void SpitAttack() {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 attackVector = (mousePos - rb.position).normalized;

        for (int i = 0; i < heldFlies; i++) {
            GameObject fly = Instantiate(flyProjectilePrefab);
            Rigidbody2D flyrb = fly.GetComponent<Rigidbody2D>();
            flyrb.position = rb.position;
            flyrb.linearVelocity = attackVector * flyProjectileSpeed;
            fly.GetComponent<SpitFlyProjectile>().projectileDamage = flyProjectileDamage;
        }
        heldFlies = 0;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)attackVectorGizmo);
    }
}
