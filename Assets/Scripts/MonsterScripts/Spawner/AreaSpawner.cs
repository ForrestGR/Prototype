using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MonsterSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] monsterPrefabs; // Array von Monstervorlagen, die gespawnt werden k�nnen
    [SerializeField] private float spawnInterval = 2f; // Zeitintervall zwischen den Spawns
    [SerializeField] private int maxMonsters = 10; // Maximale Anzahl der gleichzeitig existierenden Monster

    [SerializeField] private Vector3 spawnAreaMin; // Min-Ecke des Spawn-Bereichs
    [SerializeField] private Vector3 spawnAreaMax; // Max-Ecke des Spawn-Bereichs

    private List<GameObject> spawnedMonsters = new List<GameObject>(); // Liste der aktuell gespawnten Monster

    void Start()
    {
        if (monsterPrefabs.Length == 0)
        {
            Debug.LogError("MonsterPrefabs are not assigned in the inspector!");
        }
        else
        {
            StartCoroutine(SpawnMonsters());
        }
    }

    System.Collections.IEnumerator SpawnMonsters()
    {
        while (true) // Endlos-Schleife, die kontinuierlich Monster spawnt
        {
            if (spawnedMonsters.Count < maxMonsters)
            {
                SpawnMonster();
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnMonster()
    {
        if (monsterPrefabs.Length == 0)
        {
            Debug.LogError("No monster prefabs assigned.");
            return;
        }

        // Zuf�llige Position innerhalb des Spawn-Bereichs berechnen
        Vector3 spawnPosition = GetRandomPositionWithinArea();

        // Zuf�lliges Monster aus dem Array ausw�hlen
        GameObject monsterToSpawn = monsterPrefabs[Random.Range(0, monsterPrefabs.Length)];

        // Monster am berechneten Ort instanziieren
        GameObject spawnedMonster = Instantiate(monsterToSpawn, spawnPosition, Quaternion.identity);
        spawnedMonsters.Add(spawnedMonster);

        // Event-Listener hinzuf�gen, um zu erfahren, wenn das Monster zerst�rt wird
        spawnedMonster.GetComponent<HealthGhost>().OnDestroyed += HandleMonsterDestroyed;
    }

    void HandleMonsterDestroyed(GameObject monster)
    {
        spawnedMonsters.Remove(monster);
    }

    Vector3 GetRandomPositionWithinArea()
    {
        return new Vector3(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y),
            Random.Range(spawnAreaMin.z, spawnAreaMax.z)
        );
    }

    void OnDrawGizmosSelected()
    {
        // Zeichne den Bereich im Editor f�r eine bessere Visualisierung
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube((spawnAreaMin + spawnAreaMax) / 2, spawnAreaMax - spawnAreaMin);
    }
}
