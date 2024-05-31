using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform weaponHolder;  // Ein leeres GameObject an der Position, wo die Waffe am Spieler befestigt werden soll
    public Weapon weapon;  // Die aktuell ausgerüstete Waffe
    private List<Weapon> weapons;  // Die Liste der Waffen des Spielers


    private PlayerInventory playerInventory;
    private BaseMonster baseMonster;

    void Start()
    {
        playerInventory = GetComponent<PlayerInventory>();
        weapons = playerInventory.GetWeapons();

        //// Initialisierung von baseMonster
        //baseMonster = FindObjectOfType<BaseMonster>();
        //if (baseMonster == null)
        //{
        //    Debug.LogError("BaseMonster wurde nicht gefunden!");
        //}
    }


    void Update()
    {
        // Überprüfen, ob die Taste "G" gedrückt wird, um die Waffe fallen zu lassen
        if (Input.GetKeyDown(KeyCode.G))
        {
            DropWeapon();
        }

        // Überprüfen, ob die linke Maustaste gedrückt wird, um zu schießen
        if (Input.GetMouseButton(0) && weapon != null)
        {
            weapon.Shoot();
            UpdateAmmoUI();
        }

        // Überprüfen, ob die Taste "R" gedrückt wird, um nachzuladen
        if (Input.GetKeyDown(KeyCode.R) && weapon != null && !weapon.IsReloading() && weapon.CurrentAmmo < weapon.MagazineCapacity)
        {
            StartCoroutine(weapon.Reload(playerInventory));
        }

        // Wechsel zwischen Waffen mit den Tasten 1 und 2
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipWeaponByIndex(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipWeaponByIndex(1);
        }

        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    if (baseMonster != null)
        //    {
        //        baseMonster.KillAllMonsters();
        //    }
        //    else
        //    {
        //        Debug.LogError("baseMonster ist null und kann nicht aufgerufen werden.");
        //    }
        //}


    }

    public void EquipWeapon(GameObject weapon)
    {
        if (this.weapon != null && this.weapon.gameObject != weapon)
        {
            // Optional: Die bisherige Waffe deaktivieren oder verstecken, anstatt sie zu zerstören
            this.weapon.gameObject.SetActive(false);
        }

        // Setze die neue Waffe als die aktuelle Waffe
        this.weapon = weapon.GetComponent<Weapon>();

        // Setze die neue Waffe als Kind des weaponHolder-Transforms
        this.weapon.transform.SetParent(weaponHolder);

        this.weapon.transform.localPosition = Vector3.zero;
        this.weapon.transform.localRotation = Quaternion.Euler(90, 0, 0); // Setze Rotation auf Null oder auf eine bestimmte Rotation, wenn nötig

        // Deaktiviere den Collider der Waffe, um physikalische Kollisionen zu vermeiden
        this.weapon.GetComponent<Collider>().enabled = false;

        // Optional: Die neue Waffe aktivieren, falls sie deaktiviert war
        this.weapon.gameObject.SetActive(true);

        UpdateAmmoUI();
    }

    public void DropWeapon()
    {
        if (weapon != null)
        {
            // Entferne die Waffe vom weaponHolder
            weapon.transform.SetParent(null);

            // Setze die Position der Waffe auf die aktuelle Position des Spielers
            weapon.transform.position = transform.position;

            // Aktiviere den Collider der Waffe wieder
            weapon.GetComponent<Collider>().enabled = true;

            // Setze currentWeapon auf null, da die Waffe jetzt fallen gelassen wurde
            weapon = null;
        }
    }

    private void EquipWeaponByIndex(int index)
    {
        if (index < weapons.Count)
        {
            EquipWeapon(weapons[index].gameObject);
        }
    }

    public void UpdateAmmoUI()
    {
        AmmoCountUI ammoUI = FindObjectOfType<AmmoCountUI>();
        if (ammoUI != null && weapon != null)
        {
            ammoUI.UpdateCurrentAmmoCount(weapon.CurrentAmmo, weapon.MagazineCapacity);
        }
    }
}
