using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Camera mainCamera; // Die Hauptkamera
    [SerializeField] private float rotationSpeed = 5f; // Drehgeschwindigkeit

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        LookAtMouse();
    }

    private void LookAtMouse()
    {
        if (mainCamera == null)
        {
            Debug.LogError("Main Camera is not assigned.");
            return;
        }

        // Holen Sie sich die Mausposition in Bildschirmkoordinaten
        Vector3 mouseScreenPosition = Input.mousePosition;

        // Konvertiere die Mausposition in Weltkoordinaten auf der Höhe des Spielers
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = mainCamera.ScreenPointToRay(mouseScreenPosition);
        float hitDist = 0.0f;

        if (playerPlane.Raycast(ray, out hitDist))
        {
            Vector3 mouseWorldPosition = ray.GetPoint(hitDist);

            // Berechne die Richtung vom Charakter zur Mausposition
            Vector3 direction = (mouseWorldPosition - transform.position).normalized;
            direction.y = 0; // Behalte die Drehung in der X-Z-Ebene bei

            // Berechne den Zielwinkel
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Dreh den Charakter in Richtung der Mausposition
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}