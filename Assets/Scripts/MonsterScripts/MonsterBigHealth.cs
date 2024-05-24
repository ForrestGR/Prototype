using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBigHealth : MonoBehaviour, IMonsterHealth
{
    [SerializeField] private int maxHealth = 200;
    [SerializeField] private int currentHealth;
    [SerializeField] private GameObject lootPrefab;  // Referenz zum Loot-Prefab
    [SerializeField] private Transform lootSpawnPoint;  // Optional: Punkt, an dem das Loot gespawnt wird
    [SerializeField] private float dropChance = 2f;  // Chance für das Droppen des Loots
    private bool isDead = false;  // Variable, um zu überprüfen, ob das Monster bereits tot ist
    [SerializeField] private int xpValue = 50; // XP-Wert, den das Monster beim Tod gibt


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
            if (randomValue < dropChance)
            {
                Vector3 spawnPosition = lootSpawnPoint != null ? lootSpawnPoint.position : transform.position;
                Instantiate(lootPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
