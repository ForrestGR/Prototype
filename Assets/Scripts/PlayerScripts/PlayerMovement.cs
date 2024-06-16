using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Bewegungsgeschwindigkeit des Spielers
    public float jumpForce = 5f; // Sprungkraft des Spielers
    public float groundCheckDistance = 0.1f; // Distanz zur �berpr�fung, ob der Spieler den Boden ber�hrt
    public LayerMask groundLayer; // LayerMask zur Bestimmung, welche Layer als Boden gelten
    public bool isWalking;

    private Rigidbody rb;
    private bool isGrounded;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Initialisiere die Bewegungsrichtung als Vektor
        Vector3 moveDirection = Vector3.zero;

        // �berpr�fe, welche Tasten gedr�ckt sind, und aktualisiere die Bewegungsrichtung entsprechend
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += Vector3.right;
        }

        // Normiere den Bewegungsvektor, um gleichm��ige Bewegung zu gew�hrleistenwX
        moveDirection.Normalize();

        // Shift dr�cken zum rennen
        float currentSpeed = speed;
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            currentSpeed *= 2f;
        }

        // Bewege den Spieler basierend auf der Bewegungsrichtung und der Geschwindigkeit
        transform.position += moveDirection * currentSpeed * Time.deltaTime;

        // Animator
        if (moveDirection != Vector3.zero)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

        // �berpr�fe, ob die Sprungtaste gedr�ckt ist und der Spieler am Boden ist, und springe dann
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // Spieler ist in der Luft
        }

        // �berpr�fe, ob der Spieler den Boden ber�hrt
        CheckGrounded();
    }

    private void CheckGrounded()
    {
        // Bodenpr�fung mit einem Raycast nach unten
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance, groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
