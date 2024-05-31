using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BronzeCountUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bronzeCountText;

    private PlayerInventory playerInventory;

    private void Start()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
        if (playerInventory != null)
        {
            playerInventory.OnBronzeChanged += UpdateBronzeCount;
            // Initial update of ammo count text
            UpdateBronzeCount(playerInventory.GetBronzeCount());
        }
    }


    public void UpdateBronzeCount(int currentBronze)
    {
        if (bronzeCountText != null)
        {
            bronzeCountText.text = "Bronze: " + currentBronze;
        }
    }

}
