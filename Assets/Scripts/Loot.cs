using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    [SerializeField] private int value = 10;  // Wert des Loots

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if (playerInventory != null)
        {
            playerInventory.PickupLoot(value);
            Destroy(gameObject);  // Zerstört das Loot-Objekt nach dem Aufheben
        }
    }
}
