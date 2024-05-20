using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 20f;  // Geschwindigkeit des Projektils
    [SerializeField] private int damage = 50;    // Schaden, den das Projektil zufügt

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }


    void OnTriggerEnter(Collider other)
    {
        // Hier prüfen, ob das getroffene Objekt ein Monster ist, IMonsterHealth
        IMonsterHealth monsterHealth = other.GetComponent<IMonsterHealth>();

        if (monsterHealth != null)
        {
            monsterHealth.TakeDamage(damage);  // Beispiel-Schaden
            Destroy(gameObject);  // Zerstört die Kugel nach der Kollision
        }
    }

}
