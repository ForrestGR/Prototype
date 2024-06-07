using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject[] monsterPrefabs;  // Array von verschiedenen Monster-Prefabs
    public Transform player;  // Referenz zum Spieler-Objekt
    public float spawnInterval = 2f;  // Intervallzeit in Sekunden
    public Vector3 spawnAreaSize = new Vector3(10, 0, 10);  // Größe des Spawnbereichs
    public float minSpawnDistanceFromPlayer = 5f;  // Mindestabstand vom Spieler
    public int maxSpawnAttempts = 100;  // Maximale Anzahl von Versuchen, um eine gültige Position zu finden

    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    private IEnumerator SpawnMonsters()
    {
        while (true)
        {
            SpawnMonster();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnMonster()
    {
        // Wähle ein zufälliges Monster-Prefab aus dem Array
        int randomIndex = Random.Range(0, monsterPrefabs.Length);
        GameObject monsterPrefab = monsterPrefabs[randomIndex];

        Vector3 spawnPosition;
        int attempts = 0;

        do
        {
            spawnPosition = GetRandomSpawnPosition();
            attempts++;
        } while (Vector3.Distance(spawnPosition, player.position) < minSpawnDistanceFromPlayer && attempts < maxSpawnAttempts);

        if (attempts >= maxSpawnAttempts)
        {
            Debug.LogWarning("Failed to find a valid spawn position after maximum attempts.");
            return;  // Optional: Abbrechen, wenn keine gültige Position gefunden wird
        }

        GameObject newMonster = Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);

        // Setze die Spieler-Referenz des neu gespawnten Monsters
        BaseMonsterAI monsterScript = newMonster.GetComponent<BaseMonsterAI>();
        if (monsterScript != null)
        {
            monsterScript.player = player;
        }
        else
        {
            Debug.LogError("The spawned monster does not have a BaseMonsterAI component.");
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2),
            Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
        );
        return transform.position + randomPosition;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, spawnAreaSize);
    }
}
