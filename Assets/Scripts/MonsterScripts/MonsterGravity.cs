//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MonsterGravity : MonoBehaviour
//{
//    public float gravity = -9.81f;  // Schwerkraftkraft
//    public LayerMask groundLayer;  // Layer für den Boden
//    private Vector3 velocity;  // Geschwindigkeit des GameObjects
//    public float groundCheckDistance = 0.1f;  // Abstand für die Bodenprüfung
//    public Transform groundCheckPoint; // Optional: Punkt zur Bodenprüfung, z.B. unter dem Monster

//    void Update()
//    {
//        ApplyGravity();
//    }

//    private void ApplyGravity()
//    {
//        if (!IsGrounded())
//        {
//            // Manuelle Anwendung der Schwerkraft
//            velocity.y += gravity * Time.deltaTime;
//        }
//        else
//        {
//            // Reset der Fallgeschwindigkeit, wenn auf dem Boden
//            velocity.y = 0;
//        }

//        // Aktualisiere die Position basierend auf der Schwerkraft
//        transform.position += velocity * Time.deltaTime;
//    }

//    private bool IsGrounded()
//    {
//        // Verwende den groundCheckPoint, wenn er gesetzt ist, ansonsten die Transform-Position
//        Vector3 checkPosition = groundCheckPoint != null ? groundCheckPoint.position : transform.position;

//        // Raycast von der Position des Monsters nach unten, um den Boden zu erkennen
//        return Physics.Raycast(checkPosition, Vector3.down, groundCheckDistance, groundLayer);
//    }

//    private void OnDrawGizmosSelected()
//    {
//        Gizmos.color = Color.red;
//        Vector3 checkPosition = groundCheckPoint != null ? groundCheckPoint.position : transform.position;
//        Gizmos.DrawLine(checkPosition, checkPosition + Vector3.down * groundCheckDistance);
//    }
//}

















///*
//using UnityEngine;

//public class MonsterGravity : MonoBehaviour
//{
//    public float gravity = -9.81f; // Schwerkraftkraft
//    public LayerMask groundLayer; // Layer für den Boden
//    private Vector3 velocity; // Geschwindigkeit des GameObjects

//    void Update()
//    {
//        // Manuelle Anwendung der Schwerkraft
//        velocity.y += gravity * Time.deltaTime;
//        transform.position += velocity * Time.deltaTime;

//        // Überprüfen, ob das Monster den Boden berührt
//        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, Mathf.Abs(velocity.y * Time.deltaTime), groundLayer))
//        {
//            velocity.y = 0;
//            transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
//        }
//    }
//}
//*/