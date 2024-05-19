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

        // Normiere den Bewegungsvektor, um gleichm��ige Bewegung zu gew�hrleisten
        moveDirection.Normalize();

        // Bewege den Spieler basierend auf der Bewegungsrichtung und der Geschwindigkeit
        transform.position += moveDirection * speed * Time.deltaTime;
    }
}
