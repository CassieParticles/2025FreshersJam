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
    private Animator anim;
    private SpriteRenderer spr;
    //

    //Serialized Attributes, this is all the attributes available to change in the Inspector
    //[SerializeField] private float acceleration = 2;
    [SerializeField][Tooltip ("The speed the frog moves at, also is the max speed")]
    private float moveSpeed = 6;

    [SerializeField][Tooltip("How quickly the frog slows down when no input is held, keep high as its mostly for game feel")]
    private float deceleration = 3;
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

        moveAction = InputSystem.actions.FindAction("Move");

        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start() {
        
    }

    //HandleInputs
    private void Update() {
        moveActionValue = moveAction.ReadValue<Vector2>();

        spr.flipX = anim.GetInteger("Direction") != 3;
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

            anim.SetBool("Idle", false);

            if (Mathf.Abs(moveActionValue.y) > Mathf.Abs(moveActionValue.x)) {
                int animDirection = (int)(-Mathf.Sign(moveActionValue.y) + 1);
                if (!anim.GetBool("Tongueing")) {
                    anim.SetInteger("Direction", animDirection);
                } 
            } else {
                int animDirection = (int)(-Mathf.Sign(moveActionValue.x) + 2);
                if (!anim.GetBool("Tongueing")) {
                    anim.SetInteger("Direction", animDirection);
                }
            }

                velocity = moveActionValue.normalized * moveSpeed;

        } else { //Not moving, decelerate
        float trueDecel = deceleration / 10;

        //If speed is low enough, stop;
        if ((velocity - (velocity * trueDecel)).magnitude < 0.1f) {
                velocity = Vector2.zero;
                anim.SetBool("Idle", true);
            } else { //Else just decelerate
                velocity -= velocity * trueDecel;
        }

    }

    //Set the actual velocity to the temp variable again
    rb.linearVelocity = velocity;

    }
}
