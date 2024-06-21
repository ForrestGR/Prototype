using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class ZombieHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth;   
    [SerializeField] private float deathDelay = 4f;

    private bool isDying = false;

    private NavMeshAgent navMeshAgent;
    private Animator animator;

    private void Start()
    {
        currentHealth = maxHealth; // Setze die aktuelle Gesundheit auf die maximale Gesundheit beim Start
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount; // Reduziere die Gesundheit um den angegebenen Betrag

        if (currentHealth <= 0f && !isDying)
        {
            
            StartCoroutine(Die()); // Starte die Die-Coroutine
        }
    }

    private IEnumerator Die()
    {
        isDying = true;
        
        UpdateAnimatorParameters();
        StopAllMovement();

        // Hier kannst du optional Todesanimationen oder andere Effekte einfügen
        yield return new WaitForSeconds(deathDelay); // Warte für die angegebene Verzögerung
        Destroy(gameObject); // Zerstöre das Zombie-GameObject
    }

    private void UpdateAnimatorParameters()
    {
        animator.SetBool("isDieing", isDying);
    }

    private void StopAllMovement()
    {
        navMeshAgent.isStopped = true; // Stoppt die Bewegung des Zombies
        navMeshAgent.velocity = Vector3.zero; // Setzt die Geschwindigkeit auf null

        // Freeze rotation
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }
}
