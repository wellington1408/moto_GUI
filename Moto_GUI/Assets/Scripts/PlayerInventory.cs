using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInventory : MonoBehaviour
{
    private int currentCoins = 0;

    private void Start()
    {
        if (!SceneManager.GetSceneByName("GUI").isLoaded)
        {
            SceneManager.LoadSceneAsync("GUI", LoadSceneMode.Additive);
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
        
        PlayerObserverManager.NotifyCoinsChanged(currentCoins);
    }
}