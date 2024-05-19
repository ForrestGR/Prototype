using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform weaponHolder;  // Ein leeres GameObject an der Position, wo die Waffe am Spieler befestigt werden soll

    private GameObject currentWeapon;

    public void EquipWeapon(GameObject weapon)
    {
        if (currentWeapon != null)
        {
            Destroy(currentWeapon);
        }

        currentWeapon = weapon;
        currentWeapon.transform.SetParent(weaponHolder);
        currentWeapon.transform.localPosition = Vector3.zero;
        currentWeapon.transform.localRotation = Quaternion.identity;
        currentWeapon.GetComponent<Collider>().enabled = false;  // Deaktiviere den Collider der Waffe

        currentWeapon = weapon;
    }
}
