using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // Das Prefab der Bullet
    [SerializeField] private Transform firePoint; // Der Punkt, von dem die Bullet abgefeuert wird
    [SerializeField] private float fireRate = 0.1f; // Feuerrate der Waffe (Schüsse pro Sekunde)
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private int bulletDamage = (int)10f;

    private float nextTimeToFire = 0f;

    public void Shooting()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire) // Linke Maustaste gedrückt
        {
            nextTimeToFire = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = firePoint.forward * bulletSpeed;

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.SetDamage(bulletDamage);
    }
}
