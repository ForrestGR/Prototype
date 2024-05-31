using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SilberCountUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI silberCountText;

    private PlayerInventory playerInventory;

    private void Start()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
        if (playerInventory != null)
        {
            playerInventory.OnGoldChanged += UpdateSilberCount;
            // Initial update of ammo count text
            UpdateSilberCount(playerInventory.GetSilberCount());
        }
    }


    public void UpdateSilberCount(int currentSilber)
    {
        if (silberCountText != null)
        {
            silberCountText.text = "Silber: " + currentSilber;
        }
    }

}
