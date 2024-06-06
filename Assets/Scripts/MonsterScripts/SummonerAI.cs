using UnityEngine;

public enum SummonerState
{
    Idle,
    Summoning,
    Attacking,
    Fleeing
}

public class SummonerAI : MonoBehaviour
{
    public GameObject minionPrefab; // Prefab des beschworenen Monsters
    public Transform summonPoint; // Punkt, an dem die Minions erscheinen
    public Transform player; // Referenz auf den Spieler, direkt im Inspektor zugewiesen
    public float summonCooldown = 5f; // Abklingzeit zwischen den Beschw�rungen
    public float summonRange = 10f; // Reichweite, in der der Beschw�rer beschw�ren kann
    public float attackRange = 5f; // Reichweite, in der der Beschw�rer angreifen kann
    public float moveSpeed = 2f; // Bewegungsgeschwindigkeit des Beschw�rers
    public float idleMoveInterval = 2f; // Intervall in Sekunden zwischen Bewegungen im Idle-Zustand

    private float lastSummonTime = 0f; // Zeitpunkt der letzten Beschw�rung
    private float lastIdleMoveTime = 0f; // Zeitpunkt der letzten Bewegung im Idle-Zustand
    private SummonerState currentState; // Der aktuelle Zustand des Beschw�rers
    private Vector3 idleMoveDirection; // Richtung der zuf�lligen Bewegung im Idle-Zustand

    void Start()
    {
        currentState = SummonerState.Idle; // Initialer Zustand des Beschw�rers
        Debug.Log("Current State: " + currentState);
    }

    void Update()
    {
        switch (currentState)
        {
            case SummonerState.Idle:
                IdleBehavior(); // Zuf�llige Bewegung im Idle-Zustand
                if (Vector3.Distance(transform.position, player.position) <= summonRange)
                {
                    currentState = SummonerState.Summoning; // Zustand auf Summoning wechseln, wenn der Spieler in Reichweite ist
                    Debug.Log("Current State: " + currentState);
                }
                break;

            case SummonerState.Summoning:
                if (Time.time >= lastSummonTime + summonCooldown)
                {
                    SummonMinion(); // Minion beschw�ren, wenn die Abklingzeit abgelaufen ist
                    lastSummonTime = Time.time; // Zeitpunkt der letzten Beschw�rung aktualisieren
                }
                if (Vector3.Distance(transform.position, player.position) <= attackRange)
                {
                    currentState = SummonerState.Attacking; // Zustand auf Attacking wechseln, wenn der Spieler in Angriffsreichweite ist
                    Debug.Log("Current State: " + currentState);
                }
                break;

            case SummonerState.Attacking:
                // Hier k�nnte Angriffslogik eingef�gt werden
                if (Vector3.Distance(transform.position, player.position) > attackRange)
                {
                    currentState = SummonerState.Summoning; // Zustand zur�ck auf Summoning wechseln, wenn der Spieler aus der Angriffsreichweite ist
                    Debug.Log("Current State: " + currentState);
                }
                break;

            case SummonerState.Fleeing:
                // Hier k�nnte Fluchtlogik eingef�gt werden
                break;
        }
    }

    void SummonMinion()
    {
        Instantiate(minionPrefab, summonPoint.position, summonPoint.rotation); // Minion am Beschw�rungspunkt erstellen
        Debug.Log("Minion Summoned");
    }

    void IdleBehavior()
    {
        if (Time.time >= lastIdleMoveTime + idleMoveInterval)
        {
            idleMoveDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized; // Zuf�llige Richtung w�hlen
            lastIdleMoveTime = Time.time; // Zeitpunkt der letzten Bewegung aktualisieren
        }

        transform.position += idleMoveDirection * moveSpeed * Time.deltaTime; // Bewegung in die zuf�llige Richtung
    }
}
