using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Ensure CoinManager is properly referenced
            var coinManager = CoinManager.Instance; // Use the static Instance property of CoinManager
            if (coinManager != null)
            {
                coinManager.CollectCoin();
            }
            else
            {
                Debug.LogError("CoinManager instance is not found in the scene!");
            }
            Destroy(gameObject);
        }
    }
}