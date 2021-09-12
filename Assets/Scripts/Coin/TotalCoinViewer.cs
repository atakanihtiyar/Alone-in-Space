﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalCoinViewer : CoinViewer
{
    protected override void OnEnable()
    {
        base.OnEnable();
        coinController.TotalCoinChanged += UpdateText;
        UpdateText(coinController.totalCoin);
    }

    private void OnDisable()
    {
        coinController.TotalCoinChanged -= UpdateText;
    }
}
