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

        if (attackAction.IsPressed()) {
            TongueAttack();
        }
    }

    private void FixedUpdate() {
        
    }

    private void TongueAttack() {
        Vector2 mousePos = Input.mousePosition;

        Vector2 attackVector = (mousePos - rb.position);
        float rangedDistance = Mathf.Min((attackVector.normalized * tongueRange).magnitude, attackVector.magnitude);

        
        
        RaycastHit2D tongueRay = Physics2D.Raycast(rb.position, attackVector, rangedDistance, LayerMask.NameToLayer("2"));
    }
}
