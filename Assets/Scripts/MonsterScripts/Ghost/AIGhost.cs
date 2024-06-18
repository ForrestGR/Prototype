using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AIGhost : MonoBehaviour
{
    public float detectionRadius = 10f; // Radius, innerhalb dessen der Spieler erkannt wird
    public float returnRadius = 15f; // Radius, ab dem das Monster zum Ursprung zur�ckkehrt
    public float wanderRadius = 5f; // Radius f�r zuf�llige Bewegung
    public float wanderInterval = 3f; // Zeitintervall f�r zuf�llige Bewegung
    public Transform player; // Referenz zum Spieler-Transform

    private Vector3 spawnPosition; // Ursprungsposition des Monsters
    private NavMeshAgent agent; // NavMeshAgent f�r die Monsterbewegung
    private bool isChasingPlayer = false; // Bool, um zu verfolgen, ob das Monster den Spieler verfolgt

    void Start()
    {
        // Setze die Ursprungsposition des Monsters
        spawnPosition = transform.position;

        // Hole den NavMeshAgent vom Monster-GameObject
        agent = GetComponent<NavMeshAgent>();

        // Starte die Coroutine f�r die zuf�llige Bewegung
        StartCoroutine(Wander());
    }

    void Update()
    {
        // Berechne die Distanz zwischen dem Monster und dem Spieler
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer <= detectionRadius)
        {
            // Wenn der Spieler innerhalb des Erkennungsradius ist, verfolge den Spieler
            isChasingPlayer = true;
            agent.SetDestination(player.position);
        }
        else if (isChasingPlayer && distanceToPlayer <= returnRadius)
        {
            // Wenn das Monster den Spieler verfolgt und der Spieler innerhalb des R�ckkehrradius ist, verfolge weiter den Spieler
            agent.SetDestination(player.position);
        }
        else if (isChasingPlayer && distanceToPlayer > returnRadius)
        {
            // Wenn das Monster den Spieler verfolgt, aber der Spieler au�erhalb des R�ckkehrradius ist, kehre zur Ursprungsposition zur�ck
            isChasingPlayer = false;
            agent.SetDestination(spawnPosition);
        }
    }

    IEnumerator Wander()
    {
        // Endlosschleife f�r die zuf�llige Bewegung
        while (true)
        {
            if (!isChasingPlayer)
            {
                // Wenn das Monster den Spieler nicht verfolgt, bewege es zuf�llig innerhalb des Wander-Radius
                Vector3 wanderTarget = spawnPosition + new Vector3(
                    Random.Range(-wanderRadius, wanderRadius),
                    0,
                    Random.Range(-wanderRadius, wanderRadius)
                );

                // �berpr�fe, ob die zuf�llige Position auf dem NavMesh liegt
                NavMeshHit hit;
                if (NavMesh.SamplePosition(wanderTarget, out hit, wanderRadius, 1))
                {
                    // Setze das Ziel des NavMeshAgent auf die zuf�llige Position
                    agent.SetDestination(hit.position);
                }
            }

            // Warte das festgelegte Intervall, bevor eine neue zuf�llige Position ausgew�hlt wird
            yield return new WaitForSeconds(wanderInterval);
        }
    }

    void OnDrawGizmosSelected()
    {
        // Zeichne den Erkennungsradius im Editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        // Zeichne den R�ckkehrradius im Editor
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, returnRadius);

        // Zeichne den Wander-Radius im Editor
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(spawnPosition, wanderRadius);
    }
}
