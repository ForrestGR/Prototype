using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Loot;

public class BulletsLoot : MonoBehaviour
{

    public enum BulletType
    {
        Bullets,
        Rockets,
    }


    [SerializeField] private BulletType bulletType;
    [SerializeField] private int value = 10;

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if (playerInventory != null)
        {
            playerInventory.PickupBullets(bulletType, value);
            Destroy(gameObject);  // Zerstört das Loot-Objekt nach dem Aufheben
        }
    }

}
