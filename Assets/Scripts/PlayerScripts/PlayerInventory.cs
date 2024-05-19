using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private int lootCount = 0;

    public void PickupLoot(int value)
    {
        lootCount += value;
        Debug.Log("Loot aufgenommen! Gesamter Loot: " + lootCount);
    }
}
