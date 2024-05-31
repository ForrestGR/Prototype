using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldCountUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldCountText;

    private PlayerInventory playerInventory;

    private void Start()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
        if (playerInventory != null )
        {
            playerInventory.OnGoldChanged += UpdateGoldCount;
            // Initial update of ammo count text
            UpdateGoldCount(playerInventory.GetGoldCount());
        }
    }


    public void UpdateGoldCount (int currentGold)
    {
        if ( goldCountText != null )
        {
            goldCountText.text = " Gold: " + currentGold;
        }
    }

}
