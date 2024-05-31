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

    private void UpdateHealthbar(int currentHealth, int maxHealth)
    {
        if (healthbar != null)
        {
            healthbar.value = (float)currentHealth / maxHealth;
        }
    }
}
