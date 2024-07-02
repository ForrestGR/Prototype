using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    //Variables
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private float detectionRange;

    [SerializeField] Slider healthBar;

    private Animator animator;

    //Event
    public event Action OnHealthBelowThreshold;

    //Getter&Setter
    //public float CurrentHealth { get; private set; }

    private void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        healthBar.value = currentHealth;
    }

    public void TakeDamage(float amount)
    {
        if (currentHealth <= 0) return;

        currentHealth -= amount;
        healthBar.value = currentHealth;

        if (currentHealth <= maxHealth*0.5)
        {
            OnHealthBelowThreshold?.Invoke();
        }


        if (currentHealth <= 0)
        {
            Die();
        }

    }

    private void Die()
    {
        Destroy(gameObject);
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }


    public float CurrentHealth
    {
        get { return currentHealth; }
        set { }
    }


    public float MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }


    public float DetectionRange
    {
        get { return detectionRange; }
    }

}
