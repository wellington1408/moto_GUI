using System;

public static class PlayerObserverManager
{
    public static event Action<int, int> OnCoinsChanged;
    
    public static event Action<string> OnGameOver;

    public static void NotifyCoinsChanged(int playerId, int newCoinAmount)
    {
        OnCoinsChanged?.Invoke(playerId, newCoinAmount);
    }

    public static void NotifyGameOver(string winnerText)
    {
        OnGameOver?.Invoke(winnerText);
    }
}