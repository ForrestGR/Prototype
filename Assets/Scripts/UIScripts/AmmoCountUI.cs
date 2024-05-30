using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoCountUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI maxAmmoCountText;
    [SerializeField] private TextMeshProUGUI magazineCountText;

    private PlayerInventory playerInventory;
    private Weapon currentWeapon;

    private void Start()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
        if (playerInventory != null)
        {
            playerInventory.OnAmmoChanged += UpdateAmmoCount;
            // Initial update of ammo count text
            UpdateAmmoCount(playerInventory.GetAmmoBullets());
        }

        currentWeapon = FindObjectOfType<Weapon>();
    }

    private void Update()
    {
        if (currentWeapon != null)
        {
            UpdateCurrentAmmoCount(currentWeapon.CurrentAmmo, currentWeapon.MagazineCapacity);
        }
    }

    private void UpdateAmmoCount(int currentAmmo)
    {
        if (maxAmmoCountText != null)
        {
            maxAmmoCountText.text = "Ammo: " + currentAmmo;
        }
    }

    private void UpdateCurrentAmmoCount(int currentAmmo, int magazineCapacity)
    {
        if (magazineCountText != null)
        {
            magazineCountText.text = "Magazine: " + currentAmmo + "/" + magazineCapacity;
        }
    }
}
