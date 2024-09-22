using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PlayerUI : MonoBehaviour
{

    public TextMeshProUGUI itemCountText;
    public GameObject playerUI;
    private PlayerInventory playerInventory;
    public TextMeshProUGUI winnerText;
    

    private void Start()
    {
        playerInventory = GetComponent<PlayerInventory>();
        
      
     playerInventory.itemsCollected.OnValueChanged += UpdateItemCount;

        
        if (winnerText != null)
        {
            winnerText.gameObject.SetActive(false);
        }
    }

    private void UpdateItemCount(int previousCount, int newCount)
    {
        itemCountText.text = $"Items Collected: {newCount}";
    }

    public void SetupUI(GameObject uiPrefab)
    {
 
       playerUI = Instantiate(uiPrefab, Vector3.zero, Quaternion.identity);
             
       itemCountText = playerUI.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>();

       winnerText = playerUI.transform.Find("WinnerText").GetComponent<TextMeshProUGUI>();
    }
    public void DisplayEndMessage(bool hasWon)
    {
        if (winnerText != null)
        {
            winnerText.gameObject.SetActive(true);  
            winnerText.text = hasWon ? "You Win!" : "You Lose!";  
        }

        Time.timeScale = 0;
    }
}

    

