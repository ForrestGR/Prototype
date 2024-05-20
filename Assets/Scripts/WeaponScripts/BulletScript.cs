using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 20f;  // Geschwindigkeit des Projektils
    [SerializeField] private int damage = 40;    // Schaden, den das Projektil zuf�gt

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }


    void OnTriggerEnter(Collider other)
    {
        // Hier pr�fen, ob das getroffene Objekt ein Monster ist
        MonsterHealth monsterHealth = other.GetComponent<MonsterHealth>();

        if (monsterHealth != null)
        {
            monsterHealth.TakeDamage(damage);  // Beispiel-Schaden
            Destroy(gameObject);  // Zerst�rt die Kugel nach der Kollision
        }
    }

}
