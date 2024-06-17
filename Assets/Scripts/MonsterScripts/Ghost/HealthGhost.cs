using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthGhost : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    private bool isDead = false;

    public delegate void GhostDestroyed(GameObject ghost);
    public event GhostDestroyed OnDestroyed;


    private void Start()
    {
        currentHealth = maxHealth;
    }


    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        if (currentHealth < 0)
        {
            Die();
        }
    }


    private void Die()
    {
        if (isDead) return;

        isDead = true;

        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (OnDestroyed != null)
        {
            OnDestroyed(gameObject);
        }
    }
}
