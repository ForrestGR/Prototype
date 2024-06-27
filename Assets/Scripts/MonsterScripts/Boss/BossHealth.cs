using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currenHealth;
    [SerializeField] Slider healthBar;
    [SerializeField] private float detectionRange;

    private Animator animator;


    private void Start()
    {
        currenHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        healthBar.value = currenHealth;
        
        if (currenHealth <= maxHealth*0.5)
        {
            animator.SetTrigger("stageTwo");
        }
    }

    public void TakeDamage(float amount)
    {
        currenHealth -= amount;

        if (currenHealth <= 0)
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

}
