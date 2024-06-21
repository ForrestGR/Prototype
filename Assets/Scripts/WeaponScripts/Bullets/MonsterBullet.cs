using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMonster : MonoBehaviour
{
    private int damage;
    [SerializeField] private float speed = 20f;  // Geschwindigkeit des Projektils
    [SerializeField] private float lifetime = 2f; // Lebensdauer der Kugel

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = transform.forward * speed;
        }
        Destroy(gameObject, lifetime);
    }

    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }

    void OnTriggerEnter(Collider other)
    {
        // �berpr�fe, ob das getroffene Objekt der Spieler ist
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);  // F�ge dem Spieler Schaden zu
        }

        Destroy(gameObject);  // Zerst�rt die Kugel nach der Kollision
    }
}
