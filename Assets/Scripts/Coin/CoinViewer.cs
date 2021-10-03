using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Base class for visualize coins
/// </summary>
[RequireComponent(typeof(Text))]
public abstract class CoinViewer : UpgradedMonoBehaviour
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
