using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : Singleton<CoinController>
{
    public delegate void OnCoinChange(int coin);
    public OnCoinChange TotalCoinChanged;
    public OnCoinChange TempCoinChanged;

    public int totalCoin; // Coins collected by the player in all play sessions
    public int tempCoin; // Coins collected by the player in active play session
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

    public void AddToTempCoin(int amount)
    {
        tempCoin += isDoubleCoinActive ? amount * 2 : amount;
        TempCoinChanged?.Invoke(tempCoin);
    }

    /// <returns>Returns the success of the operation</returns>
    public bool AddToTotalCoin(int amount) // return bool for buying operation success
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