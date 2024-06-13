using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMonsterAI : BaseMonsterAI
{
    [SerializeField] private Transform weaponHoldPoint; 
    [SerializeField] private GameObject weaponPrefab; 
    [SerializeField] private float shootingInterval = 2f; // Zeitintervall zwischen den Sch�ssen
    [SerializeField] private float shootDistance = 10f; // Distanz, in der das Monster schie�en soll
    [SerializeField] private float maintainDistance = 5f; // Distanz, die das Monster zum Spieler halten soll

    private float nextShootTime = 0f;

    void Start()
    {
        // Waffe dem Monster hinzuf�gen
        if (weaponPrefab != null && weaponHoldPoint != null)
        {
            Instantiate(weaponPrefab, weaponHoldPoint.position, weaponHoldPoint.rotation, weaponHoldPoint);
        }
    }

    void Update()
    {
        MoveAndShoot();
    }

    private void MoveAndShoot()
    {
        if (player == null)
        {
            Debug.LogError("Player reference is not assigned in MonsterAI script.");
            return;
        }

        // Berechne die Distanz zum Spieler
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer > maintainDistance)
        {
            // Bewege das Monster in Richtung des Spielers, wenn es zu weit weg ist
            MoveTowardsPlayer();
        }
        else if (distanceToPlayer < maintainDistance)
        {
            // Bewege das Monster weg vom Spieler, wenn es zu nah ist
            MoveAwayFromPlayer();
        }

        if (distanceToPlayer <= shootDistance && Time.time >= nextShootTime)
        {
            // Schie�e auf den Spieler, wenn er in Reichweite ist und die Schussintervalldauer vergangen ist
            ShootAtPlayer();
            nextShootTime = Time.time + shootingInterval;
        }
    }

    protected override void MoveTowardsPlayer()
    {
        base.MoveTowardsPlayer();
        // F�ge hier zus�tzliche Logik hinzu, falls n�tig
    }

    private void MoveAwayFromPlayer()
    {
        Vector3 direction = (transform.position - player.position).normalized;
        direction.y = 0; // Nur in der X-Z-Ebene bewegen
        transform.position += direction * speed * Time.deltaTime;
        transform.LookAt(player);
    }

    private void ShootAtPlayer()
    {
        // Implementiere die Schusslogik hier, z.B. Projektil erzeugen und in Richtung des Spielers schie�en
        // Hier k�nntest du eine Methode in deinem Waffenskript aufrufen, um zu schie�en
        BaseWeapon weapon = weaponHoldPoint.GetComponentInChildren<BaseWeapon>();
        if (weapon != null)
        {
            weapon.Shoot();
        }
        else
        {
            Debug.LogError("Weapon script not found on the weapon.");
        }
    }
}