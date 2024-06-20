using UnityEngine;
using UnityEngine.AI;

public class FPSController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5.0f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.0f;

    [Header("Mouse Settings")]
    [Range(50, 300)]
    public float mouseSensitivity = 100.0f;

    [Header("Audio Settings")]
    public AudioSource audioSource;
    public AudioClip[] footstepSounds;
    public float stepInterval = 0.5f;

    private CharacterController controller;
    private NavMeshAgent agent;
    private Vector3 velocity;
    private bool isGrounded;

    private Transform cameraTransform;
    private float xRotation = 0f;
    private float stepTimer;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        agent = GetComponent<NavMeshAgent>();
        cameraTransform = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;

        // Disable automatic NavMeshAgent updates
        agent.updatePosition = false;
        agent.updateRotation = false;

        stepTimer = stepInterval;
    }

    void Update()
    {
        if (controller == null || agent == null)
            return;

        // Movement
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        if (move != Vector3.zero)
        {
            agent.SetDestination(transform.position + move);
        }

        // Check for movement to play footstep sounds
        if (isGrounded && (moveX != 0 || moveZ != 0))
        {
            stepTimer -= Time.deltaTime;

            if (stepTimer <= 0f)
            {
                PlayFootstep();
                stepTimer = stepInterval;
            }
        }
        else
        {
            stepTimer = stepInterval;
        }

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Update NavMeshAgent position to follow CharacterController
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            controller.Move(agent.desiredVelocity * Time.deltaTime);
        }
        else
        {
            controller.Move(move * speed * Time.deltaTime);
        }
        agent.nextPosition = transform.position;

        // Mouse Look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void PlayFootstep()
    {
        if (footstepSounds.Length > 0)
        {
            int index = Random.Range(0, footstepSounds.Length);
            audioSource.PlayOneShot(footstepSounds[index]);
        }
    }
}
