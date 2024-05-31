using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMonster : MonoBehaviour
{
    [SerializeField] protected int maxHealth; 
    [SerializeField] protected int currentHealth;
    [SerializeField] protected GameObject lootPrefab;
    [SerializeField] protected Transform lootSpawnPoint;
    //[SerializeField][Range(0f, 1f)] private float dropChanceLoot;
    [SerializeField] protected int xpValue;

    protected bool isDead = false;


        
    //public void KillAllMonsters()
    //{
    //    currentHealth = -10;
    //}
    

}
