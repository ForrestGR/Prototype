using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthbar;

    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged += UpdateHealthbar;
            UpdateHealthbar(playerHealth.GetCurrentHealth(), playerHealth.GetMaxHealth());
        }
    }

    private void UpdateHealthbar(float currentHealth, float maxHealth)
    {
        if (healthbar != null)
        {
            healthbar.value = currentHealth / maxHealth;
        }
    }
}


