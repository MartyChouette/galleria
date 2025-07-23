using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerScript : MonoBehaviour
{
    public float moveSpeed = .5f;
    public Transform cameraRig;

    private CharacterController controller;
    private Animator animator;
    private Vector3 velocity;
    private float gravity = -9.81f;
    private float verticalVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

    }

    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // Flatten camera vectors to keep movement on the ground
        Vector3 camForward = cameraRig.forward;
        camForward.y = 0;
        camForward.Normalize();

        Vector3 camRight = cameraRig.right;
        camRight.y = 0;
        camRight.Normalize();

        Vector3 move = (camForward * input.z + camRight * input.x).normalized;

        // Apply gravity
        if (controller.isGrounded)
        {
            verticalVelocity = -1f; // Keeps character grounded
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }

        Vector3 finalMove = move * moveSpeed;
        finalMove.y = verticalVelocity;

        controller.Move(finalMove * Time.deltaTime);

        // Rotate character to face move direction
        if (move.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        // animations
        float targetSpeed = move.magnitude < 0.1f ? 0f : 0.2f;
        animator.SetFloat("speed", targetSpeed, 0.1f, Time.deltaTime);
    }
}