//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;

//public class PlayerUIController : MonoBehaviour
//{
//    [SerializeField] private Slider healthbar;
//    [SerializeField] private TextMeshProUGUI ammoCountText;

//    private PlayerHealth playerHealth;
//    private PlayerInventory playerInventory;

//    void Start()
//    {
//        playerHealth = FindObjectOfType<PlayerHealth>();
//        playerInventory = FindObjectOfType<PlayerInventory>();

//        if (playerHealth != null)
//        {
//            playerHealth.OnHealthChanged += UpdateHealthbar;
//        }

//        if (playerInventory != null)
//        {
//            playerInventory.OnAmmoChanged += UpdateAmmoCount;
//        }
//    }

//    private void UpdateHealthbar(int currentHealth, int maxHealth)
//    {
//        if (healthbar != null)
//        {
//            healthbar.value = (float)currentHealth / maxHealth;
//        }
//    }

//    private void UpdateAmmoCount(int currentAmmo)
//    {
//        if (ammoCountText != null)
//        {
//            ammoCountText.text = "Ammo: " + currentAmmo;
//        }
//    }
//}
