using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBigAI : BaseMonsterAI
{
    // Spezifische Logik für MonsterBigAI kann hier hinzugefügt werden

    protected override void MoveTowardsPlayer()
    {
        base.MoveTowardsPlayer();
        // Füge hier zusätzliche Logik hinzu, falls nötig
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        // Füge hier zusätzliche Logik hinzu, falls nötig
    }
}
