using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour
{
    public int playerId = 1;
    private int currentCoins = 0;

    private void Start()
    {
        PlayerInput pInput = GetComponent<PlayerInput>();
        if (pInput != null)
        {
            playerId = pInput.playerIndex + 1; 
        }

    
        if (GameManager.Instance != null)
        {
            GameManager.Instance.RegisterPlayer(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            currentCoins++;

          
            PlayerObserverManager.NotifyCoinsChanged(playerId, currentCoins);
            
            if (GameManager.Instance != null)
            {
                GameManager.Instance.OnCoinCollected();
            }

            Destroy(other.gameObject);
        }
    }

    public int GetCoins() => currentCoins;
}