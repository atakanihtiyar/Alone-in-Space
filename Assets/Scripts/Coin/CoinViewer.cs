using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinViewer : MonoBehaviour
{
    protected CoinController coinController;
    private Text coinText;

    private void Awake()
    {
        coinController = CoinController.Instance;
        coinText = GetComponentInChildren<Text>();
    }

    protected virtual void UpdateText(int coin)
    {
        coinText.text = coin.ToString();
    }
}
