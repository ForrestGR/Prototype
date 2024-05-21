using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47 : Weapon
{
    [SerializeField] private float fireRate = 0.1f; //Feuerrate in Sekunden zwischen den Schüssen
    private float nextTimeToFire = 0f;

    public override void Shoot()
    {
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + fireRate;
            base.Shoot();
        }
    }
}
