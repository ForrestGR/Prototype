using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject bulletPrefab; 
    [SerializeField] protected Transform firePoint; 
    [SerializeField] protected float bulletForce = 20f; 
    [SerializeField] protected int damage = 50; 
    [SerializeField] protected int maxAmmo = 10;
    [SerializeField] protected float reloadTime = 2f; 

    [SerializeField] protected int currentAmmo; // Aktuelle Anzahl der Kugeln in der Waffe
    protected bool isReloading = false; // Gibt an, ob die Waffe gerade nachl�dt

   
    protected virtual void Start()
    {
        currentAmmo = maxAmmo;  
    }

    // Methode zum Schie�en der Waffe
    public virtual void Shoot()
    {
        // �berpr�fen, ob die Waffe nachl�dt
        if (isReloading)
        {
            return; // Schie�en nicht erlauben, wenn die Waffe nachl�dt
        }

        // �berpr�fen, ob Munition vorhanden ist
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload()); // Nachladevorgang starten, wenn keine Munition vorhanden ist
            return;
        }

        // Schie�en, wenn Bullet-Prefab und Firepoint vorhanden sind
        if (bulletPrefab != null && firePoint != null)
        {
            // Kugel erstellen und abschie�en
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse); // Kugel abschie�en
            }

            // Setze den Schaden der Kugel
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                bulletScript.SetDamage(damage);
            }

            // Setze den Schaden der MonsterKugel
            BulletMonster bulletMonster = bullet.GetComponent<BulletMonster>();
            if (bulletMonster != null)
            {
                bulletMonster.SetDamage(damage);
            }

            currentAmmo--; // Verringere die aktuelle Munition nach dem Schie�en
        }
    }

    // Coroutine zum Nachladen der Waffe
    protected IEnumerator Reload()
    {
        isReloading = true; // Setzt den Zustand auf "Nachladen"
        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime); // Wartet f�r die Dauer der Nachladezeit

        currentAmmo = maxAmmo; // Setzt die aktuelle Munition nach dem Nachladen auf die maximale Munition
        isReloading = false; // Setzt den Nachladestatus zur�ck
    }
}
