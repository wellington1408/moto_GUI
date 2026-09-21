using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenage : MonoBehaviour
{
    public static GameMenage Instance { get; private set; }

    private string guiSceneName = "GUI";

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
        if (!SceneManager.GetSceneByName(guiSceneName).isLoaded)
        {
            SceneManager.LoadSceneAsync(guiSceneName, LoadSceneMode.Additive);
        }
    }

    public void RegisterPlayer(PlayerInventory player)
    {
    }

    public void OnCoinCollected()
    {
    }

    public void TriggerVictory(int winningPlayerId)
    {
        Debug.Log($"Jogador {winningPlayerId} venceu o jogo!");
        Time.timeScale = 0f;
    }
}