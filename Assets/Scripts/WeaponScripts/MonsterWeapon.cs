using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMonster : BaseWeapon
{
    // Override Shoot Methode aus BaseWeapon, ohne die UpdateAmmoUI Methode,
    // damit die UpdateAmmoUI() Methode nicht den Muniz�hler im UI durcheinander bringt. 
    // (+ Reload Mechaniken auch unn�tig hier)

    public override void Shoot()
    {
        if (bulletPrefab != null && firePoint != null && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + fireRate;

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse); // Kugel abschie�en
            }

            // Setze den Schaden der MonsterKugel
            BulletMonster bulletMonster = bullet.GetComponent<BulletMonster>();
            if (bulletMonster != null)
            {
                bulletMonster.SetDamage(damage);
            }
        }
    }
}
