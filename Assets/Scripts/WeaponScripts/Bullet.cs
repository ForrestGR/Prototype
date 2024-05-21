using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
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
        // Hier prüfen, ob das getroffene Objekt ein Monster ist, IMonsterHealth
        IMonsterHealth monsterHealth = other.GetComponent<IMonsterHealth>();

        if (monsterHealth != null)
        {
            monsterHealth.TakeDamage(damage);  // Beispiel-Schaden
        }

        Destroy(gameObject);  // Zerstört die Kugel nach der Kollision
    }
}
