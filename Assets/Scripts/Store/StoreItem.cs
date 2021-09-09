using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreItem : MonoBehaviour
{
    public Theme _theme;

    public Image backgroundImage;
    public Image armoredImage;
    public Image doubleScoreImage;
    public Image scoreImage;

    public Text nameText;
    public Text descriptionText;

    public Button buyButton;
    public Text buyText;

    private void OnEnable()
    {
        CoinController.Instance.OnTotalCoinChange += SetCostButtonInfo;
    }

    private void OnDisable()
    {
        CoinController.Instance.OnTotalCoinChange -= SetCostButtonInfo;
    }

    public void OnClick()
    {
        if (_theme.buyed)
        {
            ThemeManager.Instance.EquipTheme(_theme);
        }
        else
        {
            bool isBuySuccessful = CoinController.Instance.AddToTotalCoin(-_theme.cost);
            if (!isBuySuccessful) return;

            buyText.text = "Equip";
            ThemeManager.Instance.BuyTheme(_theme);
        }
    }

    public void SetItemInfo(Theme theme)
    {
        _theme = theme;

        backgroundImage.sprite = theme.background;
        armoredImage.sprite = theme.armored;
        doubleScoreImage.sprite = theme.doubleScore;
        scoreImage.sprite = theme.score;

        nameText.text = theme.name;
        descriptionText.text = theme.description;

        SetCostButtonInfo(CoinController.Instance.TotalCoin);
    }

    public void SetCostButtonInfo(int totalCoin)
    {
        if (_theme.buyed)
        {
            buyText.text = "Equip";
        }
        else if (totalCoin < _theme.cost)
        {
            buyText.text = "Insufficient Funds";
            buyButton.interactable = false;
        }
        else
        {
            buyText.text = _theme.cost.ToString();
        }
    }
}
