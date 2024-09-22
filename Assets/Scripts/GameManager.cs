using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  

    [SerializeField] private GameObject winnerCanvas;
    [SerializeField] private TextMeshProUGUI winnerText;

   

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
     
}

