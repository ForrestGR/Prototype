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
    [SerializeField] private GameOverManager gameOverManager;

    // Events
    public event Action<int, int> OnHealthChanged;
    public event Action<int, int> OnXPChanged;

    void Start()
    {
        currentHealth = maxHealth;

        // Events
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
        OnXPChanged?.Invoke(currentXP, xpToNextLevel);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    void Die()
    {
        Debug.Log("Player died!");
        if (gameOverManager != null)
        {
            gameOverManager.ShowGameOverScreen();
        }
        else
        {
            Debug.LogError("GameOverManager is not assigned or not found!");
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public void GainXP(int amount)
    {
        currentXP += amount;
        OnXPChanged?.Invoke(currentXP, xpToNextLevel);
        if (currentXP >= xpToNextLevel)
        {
            LevelUp();
        }
    }

    public int GetCurrentXP()
    {
        return currentXP;
    }

    public int GetXPToNextLevel()
    {
        return xpToNextLevel;
    }

    void LevelUp()
    {
        currentLevel++;
        currentXP = currentXP - xpToNextLevel;
        xpToNextLevel = Mathf.RoundToInt(xpToNextLevel * 1.5f); // XP für das nächste Level erhöhen
        maxHealth += 20; // Erhöht die maximale Gesundheit bei einem Level-Up
        currentHealth = maxHealth; // Setzt die Gesundheit auf den neuen Maximalwert
        OnXPChanged?.Invoke(currentXP, xpToNextLevel); // Aktualisiere die XP-Bar nach dem Level-Up
        //Debug.Log("Level Up! Current Level: " + currentLevel);
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    // Methode, die den aktuellen und maximalen Gesundheitswert zurückgibt
    public (int, int) GetHealthStatus()
    {
        return (currentHealth, maxHealth);
    }
}
