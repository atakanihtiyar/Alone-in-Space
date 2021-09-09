using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : Singleton<CoinController>
{
    public delegate void OnCoinChange(int coin);
    public OnCoinChange OnTotalCoinChange;
    public OnCoinChange OnTempCoinChange;

    public int TotalCoin { get; set; }
    public int TempCoin { get; set; }
    public bool IsDoubleScore { get; set; }

    private void OnEnable()
    {
        TotalCoin = PlayerPrefs.GetInt("totalCoin", 0);
        IsDoubleScore = false;
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("totalCoin", TotalCoin);
    }

    public void AddToCoin(int amount)
    {
        TempCoin += IsDoubleScore ? amount * 2 : amount;

        OnTempCoinChange?.Invoke(TempCoin);
    }

    public void AddToTotalCoin(int amount)
    {
        TotalCoin += amount;
        OnTotalCoinChange?.Invoke(TotalCoin);
    }
}
