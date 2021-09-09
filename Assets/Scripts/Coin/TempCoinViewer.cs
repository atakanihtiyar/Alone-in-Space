using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempCoinViewer : CoinViewer
{
    private void OnEnable()
    {
        coinController.OnTempCoinChange += UpdateText;
        UpdateText(coinController.TempCoin);
    }

    private void OnDisable()
    {
        coinController.OnTempCoinChange -= UpdateText;
    }
}
