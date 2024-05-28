using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class Loot : MonoBehaviour
{
    public enum LootType
    {
        Gold,
        Silver,
        Bronze,
        // F�gen Sie hier weitere Loot-Typen hinzu
    }



    [SerializeField] private LootType lootType;
    [SerializeField] private int value = 10;  // Wert des Loots, kann unterschiedlich f�r verschiedene Typen sein

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if (playerInventory != null)
        {
            playerInventory.PickupLoot(lootType, value);
            Destroy(gameObject);  // Zerst�rt das Loot-Objekt nach dem Aufheben
        }
    }


} 


