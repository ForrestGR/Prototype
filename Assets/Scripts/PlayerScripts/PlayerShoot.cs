using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // Das Prefab der Bullet
    [SerializeField] private Transform firePoint; // Der Punkt, von dem die Bullet abgefeuert wird

    private PlayerController playerController;

    void Start()
    {
        // Referenz zum PlayerController abrufen
        playerController = GetComponent<PlayerController>();
    }



    void Update()
    {
        if (playerController.currentWeapon != null && Input.GetMouseButtonDown(0)) // Linke Maustaste
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Erstellen der Bullet an der Position des FirePoints mit der gleichen Rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}





//public class PlayerShoot : MonoBehaviour
//{
//    private PlayerController playerController;

//    void Start()
//    {
//        // Referenz zum PlayerController abrufen
//        playerController = GetComponent<PlayerController>();
//    }

//    void Update()
//    {
//        if (playerController.currentWeapon != null)
//        {
//            // Hier könnte man sicherstellen, dass die Waffe tatsächlich ein AK47Shoot-Skript hat
//            AK47Shoot weaponShoot = playerController.currentWeapon.GetComponent<AK47Shoot>();
//            if (weaponShoot != null)
//            {
//                weaponShoot.Update();
//            }
//        }
//    }
//}




