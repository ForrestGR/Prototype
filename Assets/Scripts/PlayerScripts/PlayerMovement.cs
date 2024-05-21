using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Bewegungsgeschwindigkeit des Spielers

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
    }
}
