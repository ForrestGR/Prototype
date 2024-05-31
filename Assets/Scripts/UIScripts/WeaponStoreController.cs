using UnityEngine;
using UnityEngine.UI;

public class WeaponStoreController : MonoBehaviour
{
    [SerializeField] private Canvas weaponStoreCanvas; // Referenz auf den WeaponStoreUI-Canvas
    [SerializeField] private Button buyAK47Button; // Referenz auf den AK47-Kauf-Button
    [SerializeField] private Button buyFamasButton; // Referenz auf den FAMAS-Kauf-Button

    [SerializeField] private GameObject ak47Prefab; // Prefab der AK47-Waffe
    [SerializeField] private GameObject famasPrefab; // Prefab der FAMAS-Waffe

    [SerializeField] private int ak47Cost = 600;
    [SerializeField] private int famasCost = 300;

    private PlayerInventory playerInventory;
    private PlayerController playerController;

    void Start()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
        playerController = FindObjectOfType<PlayerController>();

        if (weaponStoreCanvas == null)
        {
            Debug.LogError("WeaponStoreCanvas is not assigned in the inspector.");
        }
        else
        {
            weaponStoreCanvas.enabled = false; // Canvas zu Beginn deaktivieren
        }

        if (buyAK47Button == null)
        {
            Debug.LogError("BuyAK47Button is not assigned in the inspector.");
        }
        else
        {
            buyAK47Button.onClick.AddListener(BuyAK47);
        }

        if (buyFamasButton == null)
        {
            Debug.LogError("BuyFamasButton is not assigned in the inspector.");
        }
        else
        {
            buyFamasButton.onClick.AddListener(BuyFamas);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            ToggleWeaponStore();
        }
    }

    private void ToggleWeaponStore()
    {
        if (weaponStoreCanvas != null)
        {
            weaponStoreCanvas.enabled = !weaponStoreCanvas.enabled; // Canvas ein- oder ausschalten
        }
    }

    private void BuyAK47()
    {
        if (playerInventory.HasEnoughGold(ak47Cost)) 
        {
            playerInventory.SpendGold(ak47Cost);
            GameObject ak47 = Instantiate(ak47Prefab);
            playerInventory.AddWeapon(ak47.GetComponent<Weapon>());
            playerController.EquipWeapon(ak47);
            playerController.UpdateAmmoUI();
            //Debug.Log("AK47 gekauft und ausgerüstet!");
        }
        else
        {
            Debug.LogWarning("Nicht genug Gold für AK47!");
        }
    }

    private void BuyFamas()
    {
        if (playerInventory.HasEnoughGold(famasCost)) 
        {
            playerInventory.SpendGold(famasCost);
            GameObject famas = Instantiate(famasPrefab);
            playerInventory.AddWeapon(famas.GetComponent<Weapon>());
            playerController.EquipWeapon(famas);
            playerController.UpdateAmmoUI();
            //Debug.Log("FAMAS gekauft und ausgerüstet!");
        }
        else
        {
            Debug.LogWarning("Nicht genug Gold für FAMAS!");
        }
    }
}
