using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponStoreUI : MonoBehaviour
{
    public GameObject weaponStorePanel; // Referenz zum Panel-GameObject
    public Text weaponNameText; // Referenz zum Text-Element für den Waffennamen
    public Text weaponCostText; // Referenz zum Text-Element für den Waffenpreis
    public Button purchaseButton; // Referenz zum Kauf-Button

    private WeaponStore currentStore;

    void Start()
    {
        // Stellt sicher, dass das Panel beim Start verborgen ist
        weaponStorePanel.SetActive(false);

        // Fügt dem Button eine Listener-Funktion hinzu
        purchaseButton.onClick.AddListener(OnPurchaseButtonClicked);
    }

    public void ShowStore(WeaponStore store, string weaponName, int weaponCost)
    {
        currentStore = store;
        weaponNameText.text = weaponName;
        weaponCostText.text = "Cost: " + weaponCost.ToString() + " Gold";
        weaponStorePanel.SetActive(true);
    }

    public void HideStore()
    {
        weaponStorePanel.SetActive(false);
        currentStore = null;
    }

    private void OnPurchaseButtonClicked()
    {
        if (currentStore != null)
        {
            currentStore.PurchaseWeapon();
        }
    }
}
