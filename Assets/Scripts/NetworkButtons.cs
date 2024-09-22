using System;
using Unity.Netcode;
using UnityEngine;

public class NetworkButtons : MonoBehaviour
{
    [SerializeField] private GameObject startGamePanel;
    
    private void Start()
    {
        ShowStartPanel();
    }
    

    public void StartHost()
    {
        NetworkManager.Singleton.StartHost();
    }
    public void StartServer()
    {
        NetworkManager.Singleton.StartServer();
    }
    public void StartClient()
    {
        NetworkManager.Singleton.StartClient();
    }

    private void ShowStartPanel()
    {
        startGamePanel.SetActive(true);
        
    }
  
    
}
