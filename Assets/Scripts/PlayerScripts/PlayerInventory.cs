using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int goldCount = 0;
    [SerializeField] private int silverCount = 0;
    [SerializeField] private int bronzeCount = 0;

    [SerializeField] private int ammoBullets = 0;
    [SerializeField] private int ammoRockets = 0;

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
                // F�gen Sie hier weitere F�lle f�r andere Loot-Typen hinzu
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
                // Implementiere Logik f�r Mana-Wiederherstellung
                break;
                // F�gen Sie hier weitere F�lle f�r andere Item-Typen hinzu
        }
    }

    public void PickupBullets(BulletsLoot.BulletType bulletType, int value)
    {
        switch (bulletType)
        {
            case BulletsLoot.BulletType.Bullets:
                ammoBullets += value;
                break;
            case BulletsLoot.BulletType.Rockets:
                ammoRockets += value;
                break;
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


