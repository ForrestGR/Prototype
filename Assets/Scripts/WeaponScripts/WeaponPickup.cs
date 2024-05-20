using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    private bool isPlayerInRange = false;
    private PlayerController playerController;


    void Update()
    {
        // Überprüfe, ob der Spieler in Reichweite ist und die Taste "E" drückt, um die Waffe aufzuheben
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Überprüfen, ob der Spieler bereits diese Waffe hält
            if (playerController.currentWeapon != gameObject)
            {
                playerController.EquipWeapon(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Überprüfe, ob der Spieler den Trigger betritt und speichere die Referenz zum PlayerController
        PlayerController controller = other.GetComponent<PlayerController>();
        if (controller != null)
        {
            isPlayerInRange = true;
            playerController = controller;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Überprüfe, ob der Spieler den Trigger verlässt und setze die Referenz zurück
        if (other.GetComponent<PlayerController>() != null)
        {
            isPlayerInRange = false;
            playerController = null;
        }
    }
}
