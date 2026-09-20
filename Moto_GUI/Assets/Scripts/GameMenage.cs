using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int totalCoinsInScene;
    private int collectedCoins = 0;

    private PlayerInventory player1Inventory;
    private PlayerInventory player2Inventory;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        
        if (!SceneManager.GetSceneByName("GUI").isLoaded)
        {
            SceneManager.LoadSceneAsync("GUI", LoadSceneMode.Additive);
        }

        
        totalCoinsInScene = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

   
    public void RegisterPlayer(PlayerInventory player)
    {
        if (player.playerId == 1) player1Inventory = player;
        else if (player.playerId == 2) player2Inventory = player;
    }

 
    public void OnCoinCollected()
    {
        collectedCoins++;
        
        if (collectedCoins >= totalCoinsInScene && totalCoinsInScene > 0)
        {
            CheckWinner();
        }
    }

    private void CheckWinner()
    {
        int p1Score = player1Inventory != null ? player1Inventory.GetCoins() : 0;
        int p2Score = player2Inventory != null ? player2Inventory.GetCoins() : 0;

        if (p1Score > p2Score)
            PlayerObserverManager.NotifyGameOver($"JOGADOR 1 VENCEU!\n({p1Score} vs {p2Score})");
        else if (p2Score > p1Score)
            PlayerObserverManager.NotifyGameOver($"JOGADOR 2 VENCEU!\n({p2Score} vs {p1Score})");
        else
            PlayerObserverManager.NotifyGameOver($"EMPATE!\n({p1Score} a {p2Score})");
    }
}