using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using Unity.Netcode;

public class PlayerInventory : NetworkBehaviour
{
   
    public NetworkVariable<int> itemsCollected = new NetworkVariable<int>(
        0, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);

    
    public void CollectItem()
    {
        if (!IsOwner)return;
           CollectItemServerRpc();
        
    }

   
    [ServerRpc]
    private void CollectItemServerRpc(ServerRpcParams rpcParams = default)
    {
       
        itemsCollected.Value++;

       Debug.Log($"Player {OwnerClientId} has collected {itemsCollected.Value} items.");
    }

    
    private void Start()
    {
        
        itemsCollected.OnValueChanged += (oldValue, newValue) =>
        {
            Debug.Log($"Player {OwnerClientId}'s item count changed from {oldValue} to {newValue}");
        };
    }
}