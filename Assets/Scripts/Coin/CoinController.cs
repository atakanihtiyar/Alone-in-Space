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
    public bool IsDoubleCoin { get; set; }

    private void OnEnable()
    {
        TotalCoin = PlayerPrefs.GetInt("totalCoin", 0);
        IsDoubleCoin = false;
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("totalCoin", TotalCoin);
    }

    public bool AddToTempCoin(int amount)
    {
        if ((TotalCoin + amount) < 0) return false;

        TempCoin += IsDoubleCoin ? amount * 2 : amount;
        OnTempCoinChange?.Invoke(TempCoin);

        return true;
    }

    public bool AddToTotalCoin(int amount)
    {
        if ((TotalCoin + amount) < 0) return false;

        TotalCoin += amount;
        OnTotalCoinChange?.Invoke(TotalCoin);

        return true;
    }
}
