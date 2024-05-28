using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        HealthPotion,
        ManaPotion,
        // Fügen Sie hier weitere Item-Typen hinzu
    }

    [SerializeField] private ItemType itemType;
    [SerializeField] private int value = 10;  // Wert des Items, z.B. wie viel Leben wiederhergestellt wird

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if (playerInventory != null)
        {
            playerInventory.PickupItem(itemType, value);
            Destroy(gameObject);  // Zerstört das Item-Objekt nach dem Aufheben
        }
    }
}
