using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : BaseMonsterAI
{
    // Spezifische Logik f�r MonsterAI kann hier hinzugef�gt werden

    protected override void MoveTowardsPlayer()
    {
        base.MoveTowardsPlayer();
        // F�ge hier zus�tzliche Logik hinzu, falls n�tig
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        // F�ge hier zus�tzliche Logik hinzu, falls n�tig
    }
}
