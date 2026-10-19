using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("Identificação (1 ou 2)")]
    public int playerId = 1;

    private int coins = 0;
    private int stars = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coins++;
            if (GameMenage.Instance != null)
            {
                GameMenage.Instance.OnCoinCollected(playerId, coins);
            }
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Star"))
        {
            stars++;
            if (GameMenage.Instance != null)
            {
                GameMenage.Instance.OnStarCollected(playerId, stars);
            }
            Destroy(other.gameObject);
        }
    }
}