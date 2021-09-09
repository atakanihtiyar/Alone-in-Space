using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempCoinViewer : CoinViewer
{
    protected override void OnEnable()
    {
        base.OnEnable();

        UpdateText(coinController.TempCoin);
    }
}
