using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed = 4f;
    [SerializeField] private int damage = 10;


    void Update()
    {
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
