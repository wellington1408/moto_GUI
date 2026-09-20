using System;

public static class PlayerObserverManager
{
    public static event Action<int, int> OnCoinsChanged;
    public static event Action<string> OnGameOver;

    public static void NotifyCoinsChanged(int playerId, int coins)
    {
        OnCoinsChanged?.Invoke(playerId, coins);
    }

    public static void NotifyGameOver(string message)
    {
        OnGameOver?.Invoke(message);
    }
}