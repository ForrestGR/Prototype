using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBigHealth : BaseMonster, IMonsterHealth
{
    [SerializeField] private GameObject lootPrefab;  // Referenz zum Loot-Prefab
    [SerializeField] private GameObject bulletLootPrefab; //Referenz zum Bullet Drop Prefab
    [SerializeField] private Transform lootSpawnPoint;  // Optional: Punkt, an dem das Loot gespawnt wird
    [SerializeField] private Transform bulletLootSpawnPoint;
    [SerializeField] [Range(0f, 1f)] private float dropChanceLoot;  // Chance für das Droppen des Loots
    [SerializeField] [Range(0f, 1f)] private float dropChanceBullets;


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
        DropLoot();  // Rufe die DropLoot-Methode auf
        DropBullets();

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
            float randomValue = Random.value;  // Zufälliger Wert zwischen 0 und 1
            if (randomValue < dropChanceLoot)
            {
                Vector3 spawnPositionLoot = lootSpawnPoint != null ? lootSpawnPoint.position : transform.position;
                Instantiate(lootPrefab, spawnPositionLoot, Quaternion.identity);
            }
        }
    }

    private void DropBullets()
    {
        if (bulletLootPrefab != null)
        {
            float randValue = Random.value; 
            if (Random.value < dropChanceBullets)
            {
                Vector3 spawnPositionBullet = bulletLootSpawnPoint != null ? bulletLootSpawnPoint.position : transform.position;
                Instantiate(bulletLootPrefab, spawnPositionBullet, Quaternion.identity);
            }
        }
    }
}
