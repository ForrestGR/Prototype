using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Heal : MonoBehaviour
{
    //Variables
    [SerializeField] private float healAmount = 10.0f;


    //Reference
    PlayerHealth playerHealth;


    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            playerHealth.Heal(healAmount);

        }    
    }



}
