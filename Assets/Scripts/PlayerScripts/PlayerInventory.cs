using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int goldCount = 0;
    [SerializeField] private int silberCount = 0;
    [SerializeField] private int bronzeCount = 0;

    [SerializeField] private int ammoBullets = 0;
    [SerializeField] private int ammoRockets = 0;

    //[SerializeField] private int maxWeapons = 2;

    private PlayerHealth playerHealth;

    // Liste der Waffen, die der Spieler besitzt
    [SerializeField] private List<BaseWeapon> weapons = new List<BaseWeapon>(2);// Maximale Kapazität auf 2 setzen


    // Events
    public event Action<int> OnAmmoChanged;
    public event Action<int> OnGoldChanged;
    public event Action<int> OnSilverChanged;
    public event Action<int> OnBronzeChanged;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        
        // Initiales Auslösen der Ereignisse
        OnAmmoChanged?.Invoke(ammoBullets);
        OnGoldChanged?.Invoke(goldCount);
        OnSilverChanged?.Invoke(silberCount);
        OnBronzeChanged?.Invoke(bronzeCount);
    }

    public void PickupLoot(Loot.LootType lootType, int value)
    {
        switch (lootType)
        {
            case Loot.LootType.Gold:
                goldCount += value;
                OnGoldChanged?.Invoke(goldCount); // Event auslösen
                break;
            case Loot.LootType.Silver:
                silberCount += value;
                OnSilverChanged?.Invoke(silberCount);
                break;
            case Loot.LootType.Bronze:
                bronzeCount += value;
                OnBronzeChanged?.Invoke(bronzeCount);
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

    public void PickupBullets(BulletsLoot.BulletType bulletType, int value)
    {
        switch (bulletType)
        {
            case BulletsLoot.BulletType.Bullets:
                ammoBullets += value;
                OnAmmoChanged?.Invoke(ammoBullets); // Ereignis auslösen
                break;
            case BulletsLoot.BulletType.Rockets:
                ammoRockets += value;
                break;
        }
    }

    public int GetAmmoBullets()
    {
        return ammoBullets;
    }

    public void ConsumeAmmo(int amount)
    {
        ammoBullets = Mathf.Max(0, ammoBullets - amount);
        OnAmmoChanged?.Invoke(ammoBullets); // Ereignis auslösen
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
            OnGoldChanged?.Invoke(goldCount);
        }
        else
        {
            Debug.LogWarning("Nicht genug Gold!");
        }
    }

    public int GetGoldCount()
    {
        return goldCount;
    }

    public int GetSilberCount()
    {
        return silberCount;
    }

    public int GetBronzeCount()
    {
        return bronzeCount;
    }


    public void AddWeapon(BaseWeapon weapon)
    {
        if (!weapons.Contains(weapon))
        {
            weapons.Add(weapon);
            //Debug.Log("Waffe hinzugefügt: " + weapon.name);
        }
    }

    public List<BaseWeapon> GetWeapons()
    {
        return weapons;
    }

}
