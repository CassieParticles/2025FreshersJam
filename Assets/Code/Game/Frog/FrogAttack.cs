using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FrogAttack : MonoBehaviour
{
    //Input System Files
        InputActionAsset inputActions;

        private InputAction attackAction;
        private InputAction aimAction; //For controller support if we need it down the line
    //

    //Shorthands for used components
        private Rigidbody2D rb;
    //

    //Serialized Attributes, this is all the attributes available to change in the Inspector
        [SerializeField][Tooltip("The max range of the tongue in world units, you can imagine it as how far the frog can move in 1 second with a speed of the same value")] 
        private float tongueRange = 6;

        [SerializeField][Tooltip("How long you need to wait before you can tongue again after the tongue is back")] 
        private float attackCooldown = 0.3f;
    //

    //State Variables
        Vector2 attackVectorGizmo;
    //

    //Enable and Disable when necessary
        private void OnEnable() {
            inputActions.FindActionMap("Player").Enable();
        }
        private void OnDisable() {
            inputActions.FindActionMap("Player").Disable();
        }
    //

    //Set up variables and pointers
    private void Awake() {
        attackAction = InputSystem.actions.FindAction("Attack");

        rb = GetComponent<Rigidbody2D>();
    }

    //HandleInputs
    private void Update() {
        //This is where aiming on controller would go

        if (attackAction.WasPressedThisFrame()) {
            TongueAttack();
            //Debug.Log("Tongue");
        }
    }

    private void FixedUpdate() {
        
    }

    private void TongueAttack() {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 attackVector = (mousePos - rb.position);
        attackVectorGizmo = attackVector;
        float rangedDistance = Mathf.Min((attackVector.normalized * tongueRange).magnitude, attackVector.magnitude);

        List<RaycastHit2D> tongueRay = new List<RaycastHit2D>();

        tongueRay.AddRange(Physics2D.RaycastAll(rb.position, attackVector, rangedDistance, LayerMask.NameToLayer("3")));

        foreach (RaycastHit2D hit in tongueRay) {

            if (hit && hit.transform.GetComponent<ABulletMovement>() != null) {
                //Debug.Log("Is a bullet");
                ABulletMovement bullet = hit.transform.GetComponent<ABulletMovement>();
                if (bullet is IEdible) {
                    ((IEdible)bullet).Eaten();
                    //Debug.Log("Bullet was eaten");
                }
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)attackVectorGizmo);
    }
}
