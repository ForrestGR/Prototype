using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform weaponHolder;  // Ein leeres GameObject an der Position, wo die Waffe am Spieler befestigt werden soll
    public Weapon currentWeapon;  // Die aktuell ausger�stete Waffe
    private List<Weapon> weapons;  // Die Liste der Waffen des Spielers


    private PlayerInventory playerInventory;

    void Start()
    {
        playerInventory = GetComponent<PlayerInventory>();
        weapons = playerInventory.GetWeapons();
    }


    void Update()
    {
        // �berpr�fen, ob die Taste "G" gedr�ckt wird, um die Waffe fallen zu lassen
        if (Input.GetKeyDown(KeyCode.G))
        {
            DropWeapon();
        }

        // �berpr�fen, ob die linke Maustaste gedr�ckt wird, um zu schie�en
        if (Input.GetMouseButton(0) && currentWeapon != null)
        {
            currentWeapon.Shoot();
        }

        // �berpr�fen, ob die Taste "R" gedr�ckt wird, um nachzuladen
        if (Input.GetKeyDown(KeyCode.R) && currentWeapon != null && !currentWeapon.IsReloading() && currentWeapon.CurrentAmmo < currentWeapon.MagazineCapacity)
        {
            StartCoroutine(currentWeapon.Reload(playerInventory));
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
    }

    public void EquipWeapon(GameObject weapon)
    {
        if (currentWeapon != null && currentWeapon.gameObject != weapon)
        {
            // Optional: Die bisherige Waffe deaktivieren oder verstecken, anstatt sie zu zerst�ren
            currentWeapon.gameObject.SetActive(false);
        }

        // Setze die neue Waffe als die aktuelle Waffe
        currentWeapon = weapon.GetComponent<Weapon>();

        // Setze die neue Waffe als Kind des weaponHolder-Transforms
        currentWeapon.transform.SetParent(weaponHolder);

        currentWeapon.transform.localPosition = Vector3.zero;
        currentWeapon.transform.localRotation = Quaternion.Euler(90, 0, 0); // Setze Rotation auf Null oder auf eine bestimmte Rotation, wenn n�tig

        // Deaktiviere den Collider der Waffe, um physikalische Kollisionen zu vermeiden
        currentWeapon.GetComponent<Collider>().enabled = false;

        // Optional: Die neue Waffe aktivieren, falls sie deaktiviert war
        currentWeapon.gameObject.SetActive(true);
    }

    public void DropWeapon()
    {
        if (currentWeapon != null)
        {
            // Entferne die Waffe vom weaponHolder
            currentWeapon.transform.SetParent(null);

            // Setze die Position der Waffe auf die aktuelle Position des Spielers
            currentWeapon.transform.position = transform.position;

            // Aktiviere den Collider der Waffe wieder
            currentWeapon.GetComponent<Collider>().enabled = true;

            // Setze currentWeapon auf null, da die Waffe jetzt fallen gelassen wurde
            currentWeapon = null;
        }
    }

    private void EquipWeaponByIndex(int index)
    {
        if (index < weapons.Count)
        {
            EquipWeapon(weapons[index].gameObject);
        }
    }
}
