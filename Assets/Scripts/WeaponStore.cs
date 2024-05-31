using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStore : MonoBehaviour
{
    [SerializeField] private GameObject ak47Prefab; // Das Prefab der AK47
    [SerializeField] private Transform weaponHoldPoint; // Der Punkt, an dem die Waffe in der Hand des Spielers gehalten wird
    [SerializeField] private int weaponCost = 600;

    private bool isPlayerInRange = false; // Überprüft, ob der Spieler in der Nähe ist

    private void Start()
    {
        PlayerInteraction playerInteraction = FindObjectOfType<PlayerInteraction>();
        if (playerInteraction != null)
        {
            playerInteraction.OnWeaponStoreEnter += HandlePlayerEnter;
            playerInteraction.OnWeaponStoreExit += HandlePlayerExit;
        }

    }

    private void OnDestroy()
    {
        PlayerInteraction playerInteraction = FindObjectOfType<PlayerInteraction>();
        if (playerInteraction != null)
        {
            playerInteraction.OnWeaponStoreEnter -= HandlePlayerEnter;
            playerInteraction.OnWeaponStoreExit -= HandlePlayerExit;
        }
    }

    private void HandlePlayerEnter(WeaponStore store)
    {
        if (store == this)
        {
            isPlayerInRange = true;
            Debug.Log("Player entered the weapon store range.");
        }
    }

    private void HandlePlayerExit(WeaponStore store)
    {
        if (store == this)
        {
            isPlayerInRange = false;
            Debug.Log("Player left the weapon store range.");

        }
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            PurchaseWeapon();
        }
    }

    public void PurchaseWeapon()
    {
        // Finde den Spieler
        PlayerController playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            PlayerInventory playerInventory = playerController.GetComponent<PlayerInventory>();
            if (playerInventory != null)
            {

                // Überprüfe, ob der Spieler genug Gold hat
                if (playerInventory.HasEnoughGold(weaponCost))
                {
                    // Entferne alte Waffe, falls vorhanden
                    foreach (Transform child in weaponHoldPoint)
                    {
                        Destroy(child.gameObject);
                    }

                    // Erzeuge die AK47 und setze sie in die Hand des Spielers
                    GameObject ak47 = Instantiate(ak47Prefab, weaponHoldPoint.position, weaponHoldPoint.rotation, weaponHoldPoint);
                    ak47.transform.localPosition = Vector3.zero; // Stelle sicher, dass die Waffe korrekt positioniert ist
                    ak47.transform.localRotation = Quaternion.Euler(90, 0, 0); // Stelle sicher, dass die Waffe korrekt ausgerichtet ist

                    Debug.Log("AK47 purchased and equipped.");

                    // Waffe als aktuelle Waffe des Spielers ausrüsten
                    BaseWeapon ak47Weapon = ak47.GetComponent<BaseWeapon>();
                    if (ak47Weapon != null)
                    {
                        playerController.EquipWeapon(ak47);

                        // Ziehe das Gold ab
                        playerInventory.SpendGold(weaponCost);
                    }
                    else
                    {
                        Debug.LogError("AK47 Weapon script not found on the instantiated AK47 prefab.");
                    }
                }
                else
                {
                    Debug.Log("Not enough gold to purchase AK47.");
                }
            }
        }
    }

}
