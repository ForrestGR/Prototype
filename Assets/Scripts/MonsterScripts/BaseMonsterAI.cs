using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMonsterAI : MonoBehaviour
{
    [SerializeField] public Transform player;  // Referenz zum Spieler-Transform
    [SerializeField] protected float speed = 4f;
    [SerializeField] protected int damage = 10;

    void Update()
    {
        MoveTowardsPlayer();
    }

    protected virtual void MoveTowardsPlayer()
    {
        if (player == null)
        {
            Debug.LogError("Player reference is not assigned in BaseMonsterAI script.");
            return;
        }

        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0;  // Nur in der X-Z-Ebene bewegen

        transform.position += direction * speed * Time.deltaTime;

        transform.LookAt(player);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
