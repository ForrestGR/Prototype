using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMonsterHealth : BaseMonster, IMonsterHealth
{   
    [SerializeField] private List<GameObject> lootPrefabs;  // Liste der Loot-Prefabs
    [SerializeField] private List<float> lootDropChances;  // Liste der Wahrscheinlichkeiten für jedes Loot-Prefab
    [SerializeField] private Transform lootSpawnPoint;  // Optional: Punkt, an dem das Loot gespawnt wird
    [SerializeField][Range(0f, 1f)] private float dropChance;  // Generelle Drop-Chance (0 bis 1)
   

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
        Destroy(gameObject);  // Zerstöre das Monster-GameObject
    }

    private void DropLoot()
    {
        if (lootPrefabs.Count > 0 && lootPrefabs.Count == lootDropChances.Count)
        {
            float randomValue = Random.value;  // Zufälliger Wert zwischen 0 und 1
            if (randomValue < dropChance)
            {
                Vector3 spawnPosition = lootSpawnPoint != null ? lootSpawnPoint.position : transform.position;
                GameObject selectedLootPrefab = GetRandomLootPrefab();
                if (selectedLootPrefab != null)
                {
                    Instantiate(selectedLootPrefab, spawnPosition, Quaternion.identity);
                }
            }
        }
        else
        {
            Debug.LogError("LootPrefabs und LootDropChances müssen die gleiche Anzahl von Elementen haben.");
        }
    }

    private GameObject GetRandomLootPrefab()
    {
        float totalProbability = 0f;
        foreach (float probability in lootDropChances)
        {
            totalProbability += probability;
        }

        float randomPoint = Random.value * totalProbability;
        for (int i = 0; i < lootPrefabs.Count; i++)
        {
            if (randomPoint < lootDropChances[i])
            {
                return lootPrefabs[i];
            }
            else
            {
                randomPoint -= lootDropChances[i];
            }
        }

        return null;  // Fallback, falls etwas schiefgeht
    }
}
