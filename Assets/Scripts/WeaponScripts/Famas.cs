using UnityEngine;

public class Famas : Weapon
{
    [SerializeField] private float fireRate = 0.1f; // Feuerrate in Sekunden zwischen den Schüssen
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
