using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    [Header("Textos de Moedas")]
    public TextMeshProUGUI p1CoinText;
    public TextMeshProUGUI p2CoinText;

    [Header("Painel de Vitória")]
    public GameObject winnerPanel;
    public TextMeshProUGUI winnerText;

    private void OnEnable()
    {
        PlayerObserverManager.OnCoinsChanged += UpdateCoinText;
        PlayerObserverManager.OnGameOver += ShowWinner;
    }

    private void OnDisable()
    {
        PlayerObserverManager.OnCoinsChanged -= UpdateCoinText;
        PlayerObserverManager.OnGameOver -= ShowWinner;
    }

    private void UpdateCoinText(int playerId, int count)
    {
        if (playerId == 1 && p1CoinText != null)
            p1CoinText.text = $"P1 MOEDAS: {count}";
        else if (playerId == 2 && p2CoinText != null)
            p2CoinText.text = $"P2 MOEDAS: {count}";
    }

    private void ShowWinner(string message)
    {
        if (winnerPanel != null) 
            winnerPanel.SetActive(true);

        if (winnerText != null) 
            winnerText.text = message; 
    }
}