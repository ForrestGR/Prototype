using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 20f;  // Geschwindigkeit des Projektils
    [SerializeField] private int damage = 40;    // Schaden, den das Projektil zufügt

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }


    private void OnCollisionEnter(Collision collision)
    {
        // Versuche die MonsterHealth Komponente vom kollidierenden Objekt zu bekommen
        MonsterHealth monsterHealth = collision.gameObject.GetComponent<MonsterHealth>();

        if (monsterHealth != null)
        {
            // Füge Schaden zu
            monsterHealth.TakeDamage(damage);
        }

        // Zerstöre Kugel nach Kollision
        Destroy(gameObject);
    }

}
