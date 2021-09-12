using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : Singleton<CoinController>
{
    public delegate void OnCoinChange(int coin);
    public OnCoinChange TotalCoinChanged;
    public OnCoinChange TempCoinChanged;

    public int totalCoin;
    public int tempCoin;
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

    public bool AddToTotalCoin(int amount)
    {
        if ((totalCoin + amount) < 0) return false;

        totalCoin += amount;
        TotalCoinChanged?.Invoke(totalCoin);

        return true;
    }

    public void GameOver()
    {
        AddToTotalCoin(tempCoin);
    }
}
