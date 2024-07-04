using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float currentHealth;
    [SerializeField] private float currentLevel = 1;
    [SerializeField] private float currentXP = 0;
    [SerializeField] private float xpToNextLevel = 100;
    [SerializeField] private GameOverManager gameOverManager;

    // Events
    public event Action<float, float> OnHealthChanged;
    public event Action<float, float> OnXPChanged;

    void Start()
    {
        currentHealth = maxHealth;

        // Events
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
        OnXPChanged?.Invoke(currentXP, xpToNextLevel);
    }

    public void TakeDamage(float damage)
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

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public void GainXP(float amount)
    {
        currentXP += amount;
        OnXPChanged?.Invoke(currentXP, xpToNextLevel);
        if (currentXP >= xpToNextLevel)
        {
            LevelUp();
        }
    }

    public float GetCurrentXP()
    {
        return currentXP;
    }

    public float GetXPToNextLevel()
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

    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    // Methode, die den aktuellen und maximalen Gesundheitswert zurückgibt
    public (float, float) GetHealthStatus()
    {
        return (currentHealth, maxHealth);
    }
}
