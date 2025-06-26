using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }
    public int totalCoins;
    public ExitController exit; // Drag and drop ExitController here  

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        if (exit != null)
            exit.SetExitOpen(false);
    }

    public void CollectCoin()
    {
        totalCoins--;
        if (totalCoins <= 0 && exit != null)
        {
            exit.SetExitOpen(true);
        }
    }
}