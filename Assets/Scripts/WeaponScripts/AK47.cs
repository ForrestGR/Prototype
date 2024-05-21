using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47 : Weapon
{
    public float fireRate = 0.1f; // Feuerrate in Sekunden zwischen den Schüssen
    private float nextTimeToFire = 0f;

    void Start()
    {
        damage = 40; // Setze spezifischen Schaden für die AK-47
    }

    public override void Shoot()
    {
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + fireRate;
            base.Shoot();
        }
    }
}
