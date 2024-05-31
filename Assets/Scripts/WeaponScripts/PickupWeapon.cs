using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    private bool isPlayerInRange = false;
    private PlayerController playerController;

    void Update()
    {
        // �berpr�fen, ob der Spieler in Reichweite ist und die Taste "E" dr�ckt, um die Waffe aufzuheben
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // �berpr�fen, ob der Spieler bereits diese Waffe h�lt
            if (playerController.weapon != gameObject.GetComponent<BaseWeapon>())
            {
                playerController.EquipWeapon(gameObject);
            }
            playerController.UpdateAmmoUI();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // �berpr�fen, ob der Spieler den Trigger betritt und speichere die Referenz zum PlayerController
        PlayerController controller = other.GetComponent<PlayerController>();
        if (controller != null)
        {
            isPlayerInRange = true;
            playerController = controller;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // �berpr�fen, ob der Spieler den Trigger verl�sst und setze die Referenz zur�ck
        if (other.GetComponent<PlayerController>() != null)
        {
            isPlayerInRange = false;
            playerController = null;
        }
    }
}
