using System;

public static class PlayerObserverManager
{
    public static event Action<int> OnCoinsChanged;

    public static void NotifyCoinsChanged(int newCoinAmount)
    {
        OnCoinsChanged?.Invoke(newCoinAmount);
    }
}