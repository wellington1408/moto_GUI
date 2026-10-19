using UnityEngine;
using TMPro;

public class GameMenage : MonoBehaviour
{
    public static GameMenage Instance { get; private set; }

    [Header("Textos dos Contadores (UI)")]
    public TextMeshProUGUI p1CoinsText;
    public TextMeshProUGUI p2CoinsText;
    public TextMeshProUGUI p1StarsText;
    public TextMeshProUGUI p2StarsText;

    [Header("Painéis de Vitória")]
    public GameObject p1WinScreen;
    public GameObject p2WinScreen;
    public TextMeshProUGUI victoryMessageText; 

    private int totalStarsInScene = 0;
    private int collectedStarsTotal = 0;

    private int p1Coins = 0;
    private int p2Coins = 0;
    private int p1Stars = 0;
    private int p2Stars = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        
        if (p1WinScreen != null) p1WinScreen.SetActive(false);
        if (p2WinScreen != null) p2WinScreen.SetActive(false);

       
        Invoke(nameof(ContarEstrelasIniciais), 0.3f);
    }

    private void ContarEstrelasIniciais()
    {
        GameObject[] estrelasNoMapa = GameObject.FindGameObjectsWithTag("Star");
        totalStarsInScene = estrelasNoMapa.Length;
        AtualizarUI();
    }

    public void OnCoinCollected(int playerId, int amount)
    {
        if (playerId == 1) p1Coins = amount;
        else if (playerId == 2) p2Coins = amount;

        AtualizarUI();
    }

    public void OnStarCollected(int playerId, int amount)
    {
        if (playerId == 1) p1Stars = amount;
        else if (playerId == 2) p2Stars = amount;

        collectedStarsTotal++;
        AtualizarUI();

        
        if (collectedStarsTotal >= totalStarsInScene && totalStarsInScene > 0)
        {
            FinalizarJogo();
        }
    }

    private void AtualizarUI()
    {
        if (p1CoinsText != null) p1CoinsText.text = "P1 MOEDAS: " + p1Coins;
        if (p2CoinsText != null) p2CoinsText.text = "P2 MOEDAS: " + p2Coins;
        if (p1StarsText != null) p1StarsText.text = "P1 Estrelas: " + p1Stars;
        if (p2StarsText != null) p2StarsText.text = "P2 Estrelas: " + p2Stars;
    }

    private void FinalizarJogo()
    {
        string mensagemFinal = "";

        if (p1Stars > p2Stars)
        {
            mensagemFinal = "Jogador 1 ganhou de Jogador 2 por " + p1Stars + " a " + p2Stars + "!";
            if (p1WinScreen != null) p1WinScreen.SetActive(true);
        }
        else if (p2Stars > p1Stars)
        {
            mensagemFinal = "Jogador 2 ganhou de Jogador 1 por " + p2Stars + " a " + p1Stars + "!";
            if (p2WinScreen != null) p2WinScreen.SetActive(true);
        }
        else
        {
            
            if (p1Coins > p2Coins)
            {
                mensagemFinal = "Jogador 1 ganhou de Jogador 2 no desempate de moedas (" + p1Coins + " a " + p2Coins + " moedas)!";
                if (p1WinScreen != null) p1WinScreen.SetActive(true);
            }
            else if (p2Coins > p1Coins)
            {
                mensagemFinal = "Jogador 2 ganhou de Jogador 1 no desempate de moedas (" + p2Coins + " a " + p1Coins + " moedas)!";
                if (p2WinScreen != null) p2WinScreen.SetActive(true);
            }
            else
            {
                mensagemFinal = "Empate perfeito!";
                if (p1WinScreen != null) p1WinScreen.SetActive(true);
            }
        }

        
        if (victoryMessageText != null)
        {
            victoryMessageText.text = mensagemFinal;
        }

        Debug.Log(mensagemFinal);
        Time.timeScale = 0f;
    }
}