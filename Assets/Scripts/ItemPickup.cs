using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class ItemPickup : NetworkBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player")) 
        {
           
            if (IsServer)
            {
               
                if (collision.TryGetComponent<PlayerInventory>(out PlayerInventory playerInventory))
                {
                    
                    playerInventory.CollectItem();

                   HideItemClientRpc();

                   NetworkObject.Despawn();
                }
            }
        }
    }

    [ClientRpc]
    private void HideItemClientRpc()
    {
        gameObject.SetActive(false);
    }
}