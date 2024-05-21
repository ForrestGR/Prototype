using UnityEngine;

public class Famas : Weapon
{
    public float fireRate = 0.1f; // Feuerrate in Sekunden zwischen den Schüssen
    private float nextTimeToFire = 0f;

    void Start()
    {
        damage = 30; // Setze spezifischen Schaden für die Famas
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
