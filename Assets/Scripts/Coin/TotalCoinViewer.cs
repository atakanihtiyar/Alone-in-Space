using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalCoinViewer : CoinViewer
{
    protected override void OnEnable()
    {
        base.OnEnable();

        UpdateText(coinController.TotalCoin);
    }
}
