using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class for visualize themes on store
/// </summary>
public class StoreItem : UpgradedMonoBehaviour
{
    private Theme _theme;

    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image armoredImage;
    [SerializeField] private Image doubleScoreImage;
    [SerializeField] private Image scoreImage;

    [SerializeField] private Text nameText;
    [SerializeField] private Text descriptionText;

    [SerializeField] private Button buyButton;
    [SerializeField] private Text buyText;

    private void OnEnable()
    {
        coinController.TotalCoinChanged += SetCostButtonInfo;
    }

    private void OnDisable()
    {
        coinController.TotalCoinChanged -= SetCostButtonInfo;
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

    public void SetItemInfo(Theme themeToShow)
    {
        _theme = themeToShow;

        backgroundImage.sprite = themeToShow.GetThemePart("background").sprite;
        armoredImage.sprite = themeToShow.GetThemePart("armored").sprite;
        doubleScoreImage.sprite = themeToShow.GetThemePart("double_coin").sprite;
        scoreImage.sprite = themeToShow.GetThemePart("coin").sprite;

        nameText.text = themeToShow.name;
        descriptionText.text = themeToShow.description;

        SetCostButtonInfo(coinController.totalCoin);
    }

    private void SetCostButtonInfo(int totalCoin)
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
