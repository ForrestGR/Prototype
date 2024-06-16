using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking"; // Korrigierter Parametername

    private PlayerMovement player; 
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator-Komponente fehlt am PlayerAnimator-GameObject");
        }

        // Find the PlayerMovement script on the parent object
        player = GetComponentInParent<PlayerMovement>();

        if (player == null)
        {
            Debug.LogError("PlayerMovement-Skript ist nicht zugewiesen oder nicht gefunden");
        }
    }

    private void Update()
    {
        if (player != null)
        {
            bool isWalking = player.IsWalking();
            animator.SetBool(IS_WALKING, isWalking);
        }
    }
}
