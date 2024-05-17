using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // Das Prefab der Bullet
    public Transform firePoint; // Der Punkt, von dem die Bullet abgefeuert wird

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Linke Maustaste
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
