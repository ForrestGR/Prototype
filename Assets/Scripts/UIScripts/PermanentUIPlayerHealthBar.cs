using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PermanentUIPlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthbar;
    //[SerializeField] private TextMeshProUGUI ammoCountText;

    private PlayerHealth playerHealth;
    //private PlayerInventory playerInventory;

    private void Update()
    {
        if (playerHealth != null)
        {
            // Holen der aktuellen und maximalen Gesundheit
            var (currentHealth, maxHealth) = playerHealth.GetHealthStatus();
            // Aktualisieren der Gesundheitsleiste
            UpdateHealthbar(currentHealth, maxHealth);
        }
    }




    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        //playerInventory = FindObjectOfType<PlayerInventory>();
    }

    private void UpdateHealthbar(int currentHealth, int maxHealth)
    {
        if (healthbar != null)
        {
            healthbar.value = (float)currentHealth / maxHealth;
        }
    }

    //private void UpdateAmmoCount(int currentAmmo)
    //{
    //    if (ammoCountText != null)
    //    {
    //        ammoCountText.text = "Ammo: " + currentAmmo;
    //    }
    //}
}
