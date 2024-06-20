using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab; // Das Prefab des First-Person-Controllers
    public Transform spawnPoint;    // Der Transform des Spawn-Punkts

    void Start()
    {
        if (playerPrefab != null && spawnPoint != null)
        {
            Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogError("PlayerPrefab oder SpawnPoint ist nicht zugewiesen!");
        }
    }
}
