using TMPro;
using UnityEngine;

public class AmmoCountUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI maxAmmoCountText;
    [SerializeField] private TextMeshProUGUI magazineCountText;

    private PlayerInventory playerInventory;

    private void Start()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
        if (playerInventory != null)
        {
            playerInventory.OnAmmoChanged += UpdateAmmoCount;
            // Initial update of ammo count text
            UpdateAmmoCount(playerInventory.GetAmmoBullets());
        }
    }

    public void UpdateAmmoCount(int currentAmmo)
    {
        if (maxAmmoCountText != null)
        {
            maxAmmoCountText.text = "Ammo: " + currentAmmo;
        }
    }

    public void UpdateCurrentAmmoCount(int currentAmmo, int magazineCapacity)
    {
        if (magazineCountText != null)
        {
            magazineCountText.text = "Magazine: " + currentAmmo + "/" + magazineCapacity;
        }
    }
}
