using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject bulletPrefab; // Das Prefab der Kugel
    [SerializeField] protected Transform firePoint; // Der Punkt, von dem die Kugel abgefeuert wird
    [SerializeField] protected float bulletForce = 20f; // Die Geschwindigkeit der Kugel
    [SerializeField] protected int damage = 50; // Der Schaden der Waffe

    public virtual void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
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

