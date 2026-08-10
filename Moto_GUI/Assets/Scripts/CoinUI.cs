using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;

    private void OnEnable()
    {
        PlayerObserverManager.OnCoinsChanged += UpdateCoinText;
    }

    private void OnDisable()
    {
        PlayerObserverManager.OnCoinsChanged -= UpdateCoinText;
    }

    private void UpdateCoinText(int amount)
    {
        if (coinText != null)
        {
            coinText.text = $"MOEDAS:{amount}";
        }
    }
}