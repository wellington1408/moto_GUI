using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    [Header("Textos dos Placares")]
    [SerializeField] private TextMeshProUGUI p1Text;
    [SerializeField] private TextMeshProUGUI p2Text;

    [Header("Painel de Vitória")]
    [SerializeField] private GameObject winnerPanel;
    [SerializeField] private TextMeshProUGUI winnerText;

    private void OnEnable()
    {
        PlayerObserverManager.OnCoinsChanged += UpdateCoinsDisplay;
        PlayerObserverManager.OnGameOver += DisplayWinner;
    }

    private void OnDisable()
    {
        PlayerObserverManager.OnCoinsChanged -= UpdateCoinsDisplay;
        PlayerObserverManager.OnGameOver -= DisplayWinner;
    }

    private void UpdateCoinsDisplay(int playerId, int amount)
    {
        if (playerId == 1 && p1Text != null)
        {
            p1Text.text = $"P1 Moedas: {amount}";
        }
        else if (playerId == 2 && p2Text != null)
        {
            p2Text.text = $"P2 Moedas: {amount}";
        }
    }

    private void DisplayWinner(string message)
    {
        if (winnerPanel != null) winnerPanel.SetActive(true);
        if (winnerText != null) winnerText.text = message;
    }
}