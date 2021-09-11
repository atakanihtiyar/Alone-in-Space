using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalCoinViewer : CoinViewer
{
    protected override void OnEnable()
    {
        base.OnEnable();
        coinController.OnTotalCoinChange += UpdateText;
        UpdateText(coinController.TotalCoin);
    }

    private void OnDisable()
    {
        coinController.OnTotalCoinChange -= UpdateText;
    }
}
