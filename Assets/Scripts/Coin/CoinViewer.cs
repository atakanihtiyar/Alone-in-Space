using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinViewer : UpgradedMonoBehaviour
{
    private Text coinText;

    protected virtual void OnEnable()
    {
        coinText = GetComponentInChildren<Text>();
    }

    protected virtual void UpdateText(int coin)
    {
        coinText.text = coin.ToString();
    }
}
