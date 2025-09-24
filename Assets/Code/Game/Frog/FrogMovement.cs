using UnityEngine;
using UnityEngine.InputSystem;

public class FrogMovement : MonoBehaviour {
    
    //Input System Files
        InputActionAsset inputActions;

        private InputAction moveAction;

        private Vector2 moveActionValue;
    //

    //Shorthands for used components
        private Rigidbody2D rb;
        private BoxCollider2D bc;
    //

    //Serialized Attributes, this is all the attributes available to change in the Inspector
        [SerializeField] private float moveSpeed = 2;
        [SerializeField] private float acceleration = 2;
        [SerializeField] private float deceleration = 2;
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

        moveAction = InputSystem.actions.FindAction("Move");

        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start() {
        
    }

    //HandleInputs
    private void Update() {
        moveActionValue = moveAction.ReadValue<Vector2>();
    }

    //Run all updating functions
    private void FixedUpdate() {
        Moving();
    }

    //Handle moving around the map
    private void Moving() {
        //Use temp variable for better readability
        Vector2 velocity = rb.linearVelocity;

        //If moving accelerate
        if (moveActionValue != Vector2.zero) {
            float trueAccel = acceleration / 10;

            //Cap speed if its high enough
            if ((velocity + (moveActionValue.normalized * trueAccel)).magnitude > moveSpeed) {
                velocity = moveActionValue.normalized * moveSpeed;
            } else { //Else just accelerate
                velocity += moveActionValue.normalized * trueAccel;
            }
            
        } else { //Not moving, decelerate
            float trueDecel = deceleration / 10;

            //If speed is low enough, stop;
            if ((velocity - (velocity * trueDecel)).magnitude < 0.1f) {
                velocity = Vector2.zero;
            } else { //Else just decelerate
                velocity -= velocity * trueDecel;
            }

        }

        //Set the actual velocity to the temp variable again
        rb.linearVelocity = velocity;

    }
}
