using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform weaponHolder;  // Ein leeres GameObject an der Position, wo die Waffe am Spieler befestigt werden soll

    public GameObject currentWeapon;  // Die aktuell ausgerüstete Waffe

    void Update()
    {
        // Überprüfen, ob die Taste "G" gedrückt wird, um die Waffe fallen zu lassen
        if (Input.GetKeyDown(KeyCode.G))
        {
            DropWeapon();
        }
    }


    public void EquipWeapon(GameObject weapon)
    {
        // Überprüfen, ob der Spieler bereits eine Waffe hält und ob die neue Waffe dieselbe ist
        if (currentWeapon != null && currentWeapon != weapon)
        {
            // Optional: Die bisherige Waffe deaktivieren oder verstecken, anstatt sie zu zerstören
            currentWeapon.SetActive(false);
        }

        // Setze die neue Waffe als die aktuelle Waffe
        currentWeapon = weapon;

        // Setze die neue Waffe als Kind des weaponHolder-Transforms
        currentWeapon.transform.SetParent(weaponHolder);

        // Setze die lokale Position der Waffe auf den Ursprung (relativ zum weaponHolder)
        currentWeapon.transform.localPosition = Vector3.zero;

        // Drehe die Waffe um 90 Grad auf der X-Achse (relativ zum weaponHolder)
        currentWeapon.transform.localRotation = Quaternion.Euler(90, 0, 0);

        // Deaktiviere den Collider der Waffe, um physikalische Kollisionen zu vermeiden
        currentWeapon.GetComponent<Collider>().enabled = false;

        // Optional: Die neue Waffe aktivieren, falls sie deaktiviert war
        currentWeapon.SetActive(true);
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

            //// Optional: Ein Rigidbody hinzufügen, um die Waffe physikalisch fallen zu lassen
            //Rigidbody rb = currentWeapon.GetComponent<Rigidbody>();
            //if (rb == null)
            //{
            //    rb = currentWeapon.AddComponent<Rigidbody>();
            //}

            // Setze currentWeapon auf null, da die Waffe jetzt fallen gelassen wurde
            currentWeapon = null;
        }
    }

}
