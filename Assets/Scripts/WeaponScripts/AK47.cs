using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47 : Weapon
{
    [SerializeField] private float fireRate = 0.1f; // Feuerrate in Sekunden zwischen den Schüssen
    [SerializeField] private int ak47MaxAmmo = 30; // Maximale Munition im Magazin der AK47
    private float nextTimeToFire = 0f;

    protected override void Start()
    {
        maxAmmo = ak47MaxAmmo; // Setzt die maximale Munition auf die AK47-spezifische Kapazität
        currentAmmo = maxAmmo; // Initialisiert die aktuelle Munition mit der maximalen Munition
        base.Start(); // Ruft die Start-Methode der Basisklasse auf
    }

    public override void Shoot()
    {
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + fireRate;
            base.Shoot();
        }
    }

    public void ChangeAK47AmmoCount(int newMaxAmmo)
    {
        ak47MaxAmmo = newMaxAmmo; // Setzt die neue maximale Munition für die AK47
        maxAmmo = ak47MaxAmmo; // Aktualisiert die maximale Munition der Basisklasse
        currentAmmo = Mathf.Min(currentAmmo, maxAmmo); // Stellt sicher, dass die aktuelle Munition nicht über der maximalen Munition liegt
    }
}
