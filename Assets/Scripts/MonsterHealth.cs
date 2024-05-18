using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private GameObject lootPrefab;  // Referenz zum Loot-Prefab
    [SerializeField] private Transform lootSpawnPoint;  // Optional: Punkt, an dem das Loot gespawnt wird
    [SerializeField] private float dropChance = 0.5f;  // Chance für das Droppen des Loots

    private void Start()
    {
        currentHealth = maxHealth;
    }

    // Funktion, um Schaden zu nehmen
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        DropLoot();  // Rufe die DropLoot-Methode auf
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
