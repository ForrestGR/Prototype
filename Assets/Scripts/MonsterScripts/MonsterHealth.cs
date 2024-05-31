using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : BaseMonster, IMonsterHealth
{
    //[SerializeField] private int maxHealth = 100;
    //[SerializeField] private int currentHealth;
    //private bool isDead = false;  // Variable, um zu überprüfen, ob das Monster bereits tot ist
    
    //[SerializeField] private GameObject lootPrefab;  // Referenz zum Loot-Prefab
    //[SerializeField] private Transform lootSpawnPoint;  // Optional: Punkt, an dem das Loot gespawnt wird
    [SerializeField][Range(0f, 1f)] private float dropChanceLoot = 0.2f;  // Chance für das Droppen des Loots (0 bis 1)
        
    [SerializeField] private GameObject itemPrefab; // Prefab des Items, das fallen gelassen wird
    [SerializeField][Range(0f, 1f)] private float dropChanceHealthItem = 0.5f; // Wahrscheinlichkeit, dass ein Item fallen gelassen wird
    [SerializeField] private Transform itemSpawnPoint;

    //[SerializeField] private int xpValue = 50; // XP-Wert, den das Monster beim Tod gibt

    private void Start()
    {
        currentHealth = maxHealth;
    }

    // Funktion, um Schaden zu nehmen
    public void TakeDamage(int damage)
    {
        if (isDead) return;  // Wenn das Monster bereits tot ist, führe nichts weiter aus

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;  // Doppelte Überprüfung, um sicherzustellen, dass Die nur einmal aufgerufen wird

        isDead = true;  // Setze isDead auf true, um anzuzeigen, dass das Monster tot ist
        DropLoot();     // Rufe die DropLoot-Methode auf
        DropItem();

        //XP für den Spieler, wenn Monster stirbt
        PlayerHealth player = FindObjectOfType<PlayerHealth>();
        if (player != null)
        {
            player.GainXP(xpValue);
        }

        Destroy(gameObject);  // Zerstöre das Monster-GameObject
    }

   
    private void DropLoot()
    {
        if (lootPrefab != null)
        {
            float randomValue = Random.value;
            if (randomValue < dropChanceLoot)
            {
                Vector3 spawnPosition = lootSpawnPoint != null ? lootSpawnPoint.position : transform.position;
                Instantiate(lootPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }

    void DropItem()
    {
        if (itemPrefab != null)
        {
            float randomValue = Random.value;
            if (randomValue < dropChanceHealthItem)
            {
                Vector3 spawnPositionItem = itemSpawnPoint != null ? itemSpawnPoint.position : transform.position;
                Instantiate(itemPrefab, spawnPositionItem, Quaternion.identity);
            }

        }
    }

    
}
