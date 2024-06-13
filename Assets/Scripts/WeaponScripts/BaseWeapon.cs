using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected float bulletForce;
    [SerializeField] protected int damage;
    [SerializeField] protected float fireRate;
    [SerializeField] protected int magazineCapacity;
    [SerializeField] protected int currentAmmo;
    [SerializeField] protected float reloadTime;
    //[SerializeField] protected int totalAmmo;

    protected bool isReloading = false; //Gibt an, ob die Waffe gerade nachl�dt
    protected float nextTimeToFire = 0f;

    protected PlayerInventory playerInventory;

    private AudioSource audioSource;

    [SerializeField] private AudioClip shootSound; // F�ge ein Feld f�r den Schuss-Sound hinzu

    protected virtual void Start()
    {
        currentAmmo = magazineCapacity; // Setzt die aktuelle Munition im Magazin auf die maximale Munition zu Beginn        
        playerInventory = FindObjectOfType<PlayerInventory>(); // Finde das PlayerInventory, um Nachladen zu k�nnen, nachdem die Muni leer ist

        audioSource = GetComponent<AudioSource>(); // Hole das AudioSource-Component
    }

    public virtual void Shoot()
    {
        if (isReloading)
        {
            return; // Schie�en nicht erlauben, wenn die Waffe nachl�dt
        }

        if (currentAmmo <= 0)
        {
            // Hinweis: Spieler sollten informiert werden, dass das Magazin leer ist
            Debug.Log("Out of Ammo! Reload needed.");
            StartCoroutine(Reload(playerInventory)); // Nachladen, wenn keine Kugeln mehr im Magazin sind

            return;
        }

        if (bulletPrefab != null && firePoint != null && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + fireRate;

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

            currentAmmo--; // Verringere die aktuelle Munition im Magazin nach dem Schie�en
            UpdateAmmoUI(); // Aktualisieren Sie die Munition im UI nach dem Schuss

            PlayShootSound(); // Spiele den Schuss-Sound ab
        }
    }

    private void PlayShootSound()
    {
        if (shootSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(shootSound); // Spiele den Schuss-Sound ab
        }
    }

    // Getter und Setter f�r meinen PlayerController
    public bool IsReloading()
    {
        return isReloading;
    }

    public int CurrentAmmo
    {
        get { return currentAmmo; }
    }

    public int MagazineCapacity
    {
        get { return magazineCapacity; }
    }

    public IEnumerator Reload(PlayerInventory playerInventory)
    {
        int totalAmmo = playerInventory.GetAmmoBullets();
        if (totalAmmo <= 0)
        {
            // Debug.Log("Out of Ammo!");
            yield break; // Kein Nachladen m�glich, wenn keine Gesamtmunition vorhanden ist
        }

        isReloading = true; // Setzt den Zustand auf "Nachladen"
        // Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime); // Wartet f�r die Dauer der Nachladezeit

        int ammoNeeded = magazineCapacity - currentAmmo; // Berechne, wie viele Kugeln zum Auff�llen des Magazins ben�tigt werden

        if (totalAmmo >= ammoNeeded)
        {
            currentAmmo = magazineCapacity; // F�lle das Magazin vollst�ndig auf
            playerInventory.ConsumeAmmo(ammoNeeded); // Verringere die Gesamtmunition um die nachgeladene Anzahl
        }
        else
        {
            currentAmmo += totalAmmo; // F�lle das Magazin mit der verbleibenden Gesamtmunition auf
            playerInventory.ConsumeAmmo(totalAmmo); // Setze die Gesamtmunition auf 0
        }

        isReloading = false; // Setzt den Nachladestatus zur�ck
        UpdateAmmoUI(); // Aktualisieren Sie die Munition im UI nach dem Nachladen
    }

    private void UpdateAmmoUI()
    {
        AmmoCountUI ammoUI = FindObjectOfType<AmmoCountUI>();
        if (ammoUI != null)
        {
            ammoUI.UpdateCurrentAmmoCount(currentAmmo, magazineCapacity);
        }
    }
}
