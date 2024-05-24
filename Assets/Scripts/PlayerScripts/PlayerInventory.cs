using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private int goldCount = 0;
    private int silverCount = 0;
    private int bronzeCount = 0;

    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    public void PickupLoot(Loot.LootType lootType, int value)
    {
        switch (lootType)
        {
            case Loot.LootType.Gold:
                goldCount += value;
                Debug.Log("Gold aufgenommen! Gesamtes Gold: " + goldCount);
                break;
            case Loot.LootType.Silver:
                silverCount += value;
                Debug.Log("Silber aufgenommen! Gesamtes Silber: " + silverCount);
                break;
            case Loot.LootType.Bronze:
                bronzeCount += value;
                Debug.Log("Bronze aufgenommen! Gesamtes Bronze: " + bronzeCount);
                break;
                // Fügen Sie hier weitere Fälle für andere Loot-Typen hinzu
        }
    }


    public void PickupItem(Item.ItemType itemType, int value)
    {
        switch (itemType)
        {
            case Item.ItemType.HealthPotion:
                playerHealth.Heal(value);
                break;
            case Item.ItemType.ManaPotion:
                // Implementiere Logik für Mana-Wiederherstellung
                break;
                // Fügen Sie hier weitere Fälle für andere Item-Typen hinzu
        }
    }



    public bool HasEnoughGold(int amount)
    {
        return goldCount >= amount;
    }

    public void SpendGold(int amount)
    {
        if (HasEnoughGold(amount))
        {
            goldCount -= amount;
            Debug.Log("Gold ausgegeben! Verbleibendes Gold: " + goldCount);
        }
        else
        {
            Debug.LogWarning("Nicht genug Gold!");
        }
    }



}


