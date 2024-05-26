using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Bewegungsgeschwindigkeit des Spielers
    public float jumpForce = 5f; // Sprungkraft des Spielers
    public float groundCheckDistance = 0.1f; // Distanz zur Überprüfung, ob der Spieler den Boden berührt
    public LayerMask groundLayer; // LayerMask zur Bestimmung, welche Layer als Boden gelten

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Initialisiere die Bewegungsrichtung als Vektor
        Vector3 moveDirection = Vector3.zero;

        // Überprüfe, welche Tasten gedrückt sind, und aktualisiere die Bewegungsrichtung entsprechend
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

        // Normiere den Bewegungsvektor, um gleichmäßige Bewegung zu gewährleisten
        moveDirection.Normalize();

        // Überprüfe, ob die Umschalttaste gedrückt ist, und verdopple die Geschwindigkeit
        float currentSpeed = speed;
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            currentSpeed *= 2f;
        }

        // Bewege den Spieler basierend auf der Bewegungsrichtung und der Geschwindigkeit
        transform.position += moveDirection * currentSpeed * Time.deltaTime;

        // Überprüfe, ob die Sprungtaste gedrückt ist und der Spieler am Boden ist, und springe dann
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // Spieler ist in der Luft
        }

        // Überprüfe, ob der Spieler den Boden berührt
        CheckGrounded();
    }

    private void CheckGrounded()
    {
        // Bodenprüfung mit einem Raycast nach unten
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
}
