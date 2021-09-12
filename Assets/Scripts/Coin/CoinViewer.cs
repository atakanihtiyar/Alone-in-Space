using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Base class for visualizing coins
/// </summary>
[RequireComponent(typeof(Text))]
public abstract class CoinViewer : UpgradedMonoBehaviour
{
    private Text coinText;

    protected virtual void OnEnable()
    {
        coinText = GetComponentInChildren<Text>();
    }

    /// <summary>
    /// Update text component attached to own gameobject
    /// </summary>
    /// <param name="coin">Value to write to component</param>
    protected virtual void UpdateText(int coin)
    {
        coinText.text = coin.ToString();
    }
}
