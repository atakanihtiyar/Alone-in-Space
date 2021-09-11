using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreItem : UpgradedMonoBehaviour
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
        coinController.OnTotalCoinChange += SetCostButtonInfo;
    }

    private void OnDisable()
    {
        coinController.OnTotalCoinChange -= SetCostButtonInfo;
    }

    public void OnClick()
    {
        if (_theme.buyed)
        {
            themeManager.EquipTheme(_theme);
        }
        else
        {
            bool isBuySuccessful = coinController.AddToTotalCoin(-_theme.cost);
            if (!isBuySuccessful) return;

            buyText.text = "Equip";
            themeManager.BuyTheme(_theme);
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

        SetCostButtonInfo(coinController.TotalCoin);
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
