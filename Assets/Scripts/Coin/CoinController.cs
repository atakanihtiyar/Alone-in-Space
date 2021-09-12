using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton class for manage to collected coins
/// </summary>
public class CoinController : Singleton<CoinController>
{
    /// <summary>
    /// Delegate to control what happens when coins change 
    /// </summary>
    /// <param name="coin">The value of the changed coin</param>
    public delegate void OnCoinChange(int coin);
    /// <summary>
    /// Delegate when total coin changed
    /// </summary>
    public OnCoinChange TotalCoinChanged;
    /// <summary>
    /// Delegate when temp coin changed
    /// </summary>
    public OnCoinChange TempCoinChanged;

    /// <summary>
    /// Coins collected by the player in all play sessions
    /// </summary>
    public int totalCoin;
    /// <summary>
    /// Coins collected by the player in active play session
    /// </summary>
    public int tempCoin;
    /// <summary>
    /// To check if double coin power up has been received
    /// </summary>
    public bool isDoubleCoinActive;

    private void OnEnable()
    {
        totalCoin = PlayerPrefs.GetInt("totalCoin", 0);
        isDoubleCoinActive = false;
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("totalCoin", totalCoin);
    }

    /// <summary>
    /// Add <paramref name="amount"/> to temp coin
    /// </summary>
    /// <param name="amount">Value to add </param>
    public void AddToTempCoin(int amount)
    {
        tempCoin += isDoubleCoinActive ? amount * 2 : amount;
        TempCoinChanged?.Invoke(tempCoin);
    }

    /// <summary>
    /// Add <paramref name="amount"/> to total coin
    /// </summary>
    /// <param name="amount">Value to add </param>
    /// <returns>Returns the success of the operation</returns>
    public bool AddToTotalCoin(int amount)
    {
        if ((totalCoin + amount) < 0) return false;

        totalCoin += amount;
        TotalCoinChanged?.Invoke(totalCoin);

        return true;
    }

    /// <summary>
    /// Transfer temp coin to total coin
    /// </summary>
    public void TransferTempToTotal()
    {
        AddToTotalCoin(tempCoin);
        tempCoin = 0;
    }
}