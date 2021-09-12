using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempCoinViewer : CoinViewer
{
    protected override void OnEnable()
    {
        base.OnEnable();
        coinController.TempCoinChanged += UpdateText;
        UpdateText(coinController.tempCoin);
    }

    private void OnDisable()
    {
        coinController.TempCoinChanged -= UpdateText;
    }
}
