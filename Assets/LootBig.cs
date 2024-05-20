//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class LootBig : MonoBehaviour
//{
//    [SerializeField] private int value = 50;  // Wert des Loots

//    private void OnTriggerEnter(Collider other)
//    {
//        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
//        if (playerInventory != null)
//        {
//            playerInventory.PickupLoot(value);
//            Destroy(gameObject);  // Zerstört das Loot-Objekt nach dem Aufheben
//        }
//    }
//}
