using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    [SerializeField] private Slider xpbar;

    private PlayerHealth playerXP;

    private void Start()
    {
        playerXP = GetComponent<PlayerHealth>();
        if (playerXP != null)
        {
            xpbar.maxValue = playerXP.GetXPToNextLevel(); // Setzt den Maximalwert des Sliders
            playerXP.OnXPChanged += UpdateXPBar;
            UpdateXPBar(playerXP.GetCurrentXP(), playerXP.GetXPToNextLevel());
        }
    }

    private void UpdateXPBar(float currentXP, float xpToNextLevel)
    {
        if (playerXP != null)
        {
            xpbar.value = currentXP;
            xpbar.maxValue = xpToNextLevel; // Aktualisiert den Maximalwert des Sliders nach einem Level-Up
        }
    }
}
