using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField] private int pelletsPerShot = 10; // Anzahl der Kugeln pro Schuss
    [SerializeField] private float spreadAngle = 10f; // Streuwinkel in Grad

    public override void Shoot()
    {
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + fireRate;


            for (int i = 0; i < pelletsPerShot; i++)
            {
                ShootPellet();
            }
        }
    }

    private void ShootPellet()
    {
       
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Zufällige Abweichung im Streuwinkel
                float angleOffset = Random.Range(-spreadAngle / 2, spreadAngle / 2);
                Vector3 spreadDirection = Quaternion.Euler(0, angleOffset, 0) * firePoint.forward;

                rb.AddForce(spreadDirection * bulletForce, ForceMode.Impulse);
            }

            // Setze den Schaden der Kugel
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                bulletScript.SetDamage(damage);
            }
        }
    }
}
