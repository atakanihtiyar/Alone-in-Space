using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreItem : MonoBehaviour
{
    private Theme _theme;

    public Image backgroundImage;
    public Image armoredImage;
    public Image doubleScoreImage;
    public Image scoreImage;

    public Text nameText;
    public Text descriptionText;

    public Button buyButton;
    public Text buyText;

    public void OnClick()
    {
        if (_theme.buyed)
        {
            ThemeManager.instance.EquipTheme(_theme);
        }
        else
        {
            buyText.text = "Equip";
            ThemeManager.instance.BuyTheme(_theme);
        }
    }

    public void SetItemInfo(Theme theme, int totalCoin)
    {
        _theme = theme;

        backgroundImage.sprite = theme.background;
        armoredImage.sprite = theme.armored;
        doubleScoreImage.sprite = theme.doubleScore;
        scoreImage.sprite = theme.score;

        nameText.text = theme.name;
        descriptionText.text = theme.description;

        buyText.text = theme.buyed ? "Equip" : theme.cost.ToString();

        if (theme.buyed)
        {
            buyText.text = "Equip";
        }
        else if (totalCoin < theme.cost)
        {
            buyText.text = "Insufficient Funds";
            buyButton.interactable = false;
        }
        else
        {
            buyText.text = theme.cost.ToString();
        }
    }
}
