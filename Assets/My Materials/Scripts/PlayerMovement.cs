using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;

    private Animator animator;
    private Rigidbody rb;
    private bool isAwake = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Check if the player is awake
        if (!isAwake)
        {
            // Check if the character stands up
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("StandingUp"))
            {
                // Enable movement
                isAwake = true;
            }
        }
        else
        {
            // Get movement input
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Calculate movement direction
            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;
            movement *= movementSpeed;

            // Apply movement to the rigidbody
            rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
        }
    }
}
