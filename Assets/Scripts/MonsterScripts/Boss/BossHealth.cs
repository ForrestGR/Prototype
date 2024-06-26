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


    private void Start()
    {
        currenHealth = maxHealth;
    }

    private void Update()
    {
        healthBar.value = currenHealth;
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


}
