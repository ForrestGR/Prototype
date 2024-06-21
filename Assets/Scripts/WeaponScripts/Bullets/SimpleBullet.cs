using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public float damage = 10f;
    public float lifeTime = 2f;

    private ZombieHealth zombieHealth;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); // Bewegt das Projektil nach vorne
    }

    void OnTriggerEnter(Collider other)
    {
        // Prüfen, ob das getroffene Objekt ein Health-Skript hat
        zombieHealth = other.GetComponent<ZombieHealth>();
        if (zombieHealth != null)
        {
            zombieHealth.TakeDamage(damage);
        }

        Destroy(gameObject); // Zerstört das Projektil nach dem Aufprall
    }
}
