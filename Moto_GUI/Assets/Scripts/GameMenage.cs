using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

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

    private void Start()
    {
        if (!SceneManager.GetSceneByName("GUI").isLoaded)
        {
            SceneManager.LoadSceneAsync("GUI", LoadSceneMode.Additive);
        }
    }

    public void FinalizarPartida()
    {
        PlayerInventory[] players = FindObjectsOfType<PlayerInventory>();
        
        if (players.Length < 2) return;

        PlayerInventory p1 = players[0].playerId == 1 ? players[0] : players[1];
        PlayerInventory p2 = players[0].playerId == 2 ? players[0] : players[1];

        if (p1.GetCoins() > p2.GetCoins())
            PlayerObserverManager.NotifyGameOver("JOGADOR 1 VENCEU!");
        else if (p2.GetCoins() > p1.GetCoins())
            PlayerObserverManager.NotifyGameOver("JOGADOR 2 VENCEU!");
        else
            PlayerObserverManager.NotifyGameOver("EMPATE!");
    }
}