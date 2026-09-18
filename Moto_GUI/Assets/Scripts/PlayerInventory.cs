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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoins(1);
            Destroy(other.gameObject);
        }
    }

    public void AddCoins(int amount)
    {
        currentCoins += amount;
        PlayerObserverManager.NotifyCoinsChanged(playerId, currentCoins);
    }

    public int GetCoins() => currentCoins;
}