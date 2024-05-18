using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public Transform player;  // Referenz zum Spieler-Transform
    public float speed = 4f;
    public int damage = 10;

    void Update()
    {
        if (player == null)
        {
            Debug.LogError("Player reference is not assigned in MonsterAI script.");
            return;
        }

        // Berechne die Richtung zum Spieler
        Vector3 direction = player.position - transform.position;
        direction.Normalize(); // Stelle sicher, dass die Richtung normalisiert ist (Länge 1)

        // Bewege das Monster in Richtung des Spielers
        transform.position += direction * speed * Time.deltaTime;

        // Optional: Drehung des Monsters in Richtung des Spielers
        transform.LookAt(player);
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
