using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour, IMonsterHealth
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private GameObject lootPrefab;  // Referenz zum Loot-Prefab
    [SerializeField] private Transform lootSpawnPoint;  // Optional: Punkt, an dem das Loot gespawnt wird
    [SerializeField][Range(0f, 1f)] private float dropChance = 0.2f;  // Chance f�r das Droppen des Loots (0 bis 1)
    private bool isDead = false;  // Variable, um zu �berpr�fen, ob das Monster bereits tot ist
    [SerializeField] private int xpValue = 50; // XP-Wert, den das Monster beim Tod gibt
    [SerializeField] private GameObject itemPrefab; // Prefab des Items, das fallen gelassen wird
    [SerializeField] private float dropChanceHealth = 0.5f; // Wahrscheinlichkeit, dass ein Item fallen gelassen wird

    private void Start()
    {
        currentHealth = maxHealth;
    }

    // Funktion, um Schaden zu nehmen
    public void TakeDamage(int damage)
    {
        if (isDead) return;  // Wenn das Monster bereits tot ist, f�hre nichts weiter aus

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;  // Doppelte �berpr�fung, um sicherzustellen, dass Die nur einmal aufgerufen wird

        isDead = true;  // Setze isDead auf true, um anzuzeigen, dass das Monster tot ist
        DropLoot();  // Rufe die DropLoot-Methode auf

        //XP f�r den Spieler, wenn Monster stirbt
        PlayerHealth player = FindObjectOfType<PlayerHealth>();
        if (player != null)
        {
            player.GainXP(xpValue);
        }

        Destroy(gameObject);  // Zerst�re das Monster-GameObject
    }


    void DropItem()
    {
        if (Random.value < dropChanceHealth)
        {
            Instantiate(itemPrefab, transform.position, Quaternion.identity);
        }
    }

    private void DropLoot()
    {
        if (lootPrefab != null)
        {
            float randomValue = Random.value;  // Zuf�lliger Wert zwischen 0 und 1
            if (randomValue < dropChanceHealth)
            {
                Vector3 spawnPosition = lootSpawnPoint != null ? lootSpawnPoint.position : transform.position;
                Instantiate(lootPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }














    //[SerializeField] private int maxHealth = 100;
    //[SerializeField] private int currentHealth;
    //[SerializeField] private GameObject lootPrefab;  // Referenz zum Loot-Prefab
    //[SerializeField] private Transform lootSpawnPoint;  // Optional: Punkt, an dem das Loot gespawnt wird
    //[SerializeField][Range(0f, 1f)] private float dropChance = 0.2f;  // Chance f�r das Droppen des Loots (0 bis 1)

    //private void Start()
    //{
    //    currentHealth = maxHealth;
    //}

    //// Funktion, um Schaden zu nehmen
    //public void TakeDamage(int damage)
    //{
    //    currentHealth -= damage;

    //    if (currentHealth <= 0)
    //    {
    //        Die();
    //    }
    //}

    //private void Die()
    //{
    //    DropLoot();  // Rufe die DropLoot-Methode auf
    //    Destroy(gameObject);  // Zerst�re das Monster-GameObject
    //}

    //private void DropLoot()
    //{
    //    if (lootPrefab != null)
    //    {
    //        float randomValue = Random.value;  // Zuf�lliger Wert zwischen 0 und 1
    //        if (randomValue < dropChance)
    //        {
    //            Vector3 spawnPosition = lootSpawnPoint != null ? lootSpawnPoint.position : transform.position;
    //            Instantiate(lootPrefab, spawnPosition, Quaternion.identity);
    //        }
    //    }
    //}
}
