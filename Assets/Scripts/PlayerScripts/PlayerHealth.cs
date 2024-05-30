using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private int currentLevel = 1;
    [SerializeField] private int currentXP = 0;
    [SerializeField] private int xpToNextLevel = 100;


    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Implementiere, was passiert, wenn der Spieler stirbt
        Debug.Log("Player died!");
        Destroy(gameObject);
    }



    public void GainXP(int amount)
    {
        currentXP += amount;
        if (currentXP >= xpToNextLevel)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        currentLevel++;
        currentXP = currentXP - xpToNextLevel;
        xpToNextLevel = Mathf.RoundToInt(xpToNextLevel * 1.5f); // XP f�r das n�chste Level erh�hen
        maxHealth += 20; // Erh�ht die maximale Gesundheit bei einem Level-Up
        currentHealth = maxHealth; // Setzt die Gesundheit auf den neuen Maximalwert
        Debug.Log("Level Up! Current Level: " + currentLevel);
    }



    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }


    //Methode, die den aktuellen und maximalen Gesundheitswert zur�ckgibt
    public (int, int) GetHealthStatus()
    {
        return (currentHealth, maxHealth);
    }


}




//Ereignis basierter Ansatz

////PlayerHealth.cs
//public class PlayerHealth : MonoBehaviour
//{
//    public event Action<int, int> OnHealthChanged;

//    private void Start()
//    {
//        Initiale Gesundheitswert
//        OnHealthChanged?.Invoke(currentHealth, maxHealth);
//    }

//    public void TakeDamage(int damage)
//    {
//        currentHealth -= damage;
//        OnHealthChanged?.Invoke(currentHealth, maxHealth);
//    }

//    public void Heal(int amount)
//    {
//        currentHealth += amount;
//        OnHealthChanged?.Invoke(currentHealth, maxHealth);
//    }
//}

//PlayerUIController.cs
//public class PlayerUIController : MonoBehaviour
//{
//    private PlayerHealth playerHealth;

//    void Start()
//    {
//        playerHealth = FindObjectOfType<PlayerHealth>();
//        playerHealth.OnHealthChanged += UpdateHealthbar;
//    }

//    private void UpdateHealthbar(int currentHealth, int maxHealth)
//    {
//        healthbar.value = (float)currentHealth / maxHealth;
//    }
//}
