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


    //private void OnCollisionEnter(Collision collision)
    //{
    //    // Versuche die MonsterHealth Komponente vom kollidierenden Objekt zu bekommen
    //    MonsterHealth monsterHealth = collision.gameObject.GetComponent<MonsterHealth>();

    //    if (monsterHealth != null)
    //    {
    //        // F�ge Schaden zu
    //        monsterHealth.TakeDamage(damage);
    //    }

    //    // Zerst�re Kugel nach Kollision
    //    Destroy(gameObject);
    //}



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
