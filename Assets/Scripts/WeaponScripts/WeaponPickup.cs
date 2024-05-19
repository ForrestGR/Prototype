//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    private bool isPlayerInRange = false;
    private PlayerController playerController;

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            playerController.EquipWeapon(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        if (controller != null)
        {
            isPlayerInRange = true;
            playerController = controller;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            isPlayerInRange = false;
            playerController = null;
        }
    }
}
