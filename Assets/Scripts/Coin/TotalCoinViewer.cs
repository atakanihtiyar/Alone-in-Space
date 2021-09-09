using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalCoinViewer : CoinViewer
{
    private void OnEnable()
    {
        coinController.OnTotalCoinChange += UpdateText;
        UpdateText(coinController.TotalCoin);
    }

    private void OnDisable()
    {
        coinController.OnTotalCoinChange -= UpdateText;
    }
}
