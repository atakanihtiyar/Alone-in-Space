using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private int coin;

    private void OnEnable()
    {
        coin = PlayerPrefs.GetInt("totalCoin", 0);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("totalCoin", coin);
    }

    public void AddCoin(int amount)
    {
        coin += amount;
    }
}
