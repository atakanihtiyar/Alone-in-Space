using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreItem : MonoBehaviour
{
    public Image backgroundImage;
    public Image armoredImage;
    public Image doubleScoreImage;
    public Image scoreImage;

    public Text nameText;
    public Text descriptionText;

    public Button buyButton;
    public Text buyText;

    public void BuyItem()
    {
        string myName = transform.Find("NameText").GetComponent<Text>().text;
        transform.Find("BuyButton").Find("CostText").GetComponent<Text>().text = "";

        ThemeManager.instance.BuyTheme(myName);
    }

    public void SetItemInfo(Theme theme)
    {
        backgroundImage.sprite = theme.background;
        armoredImage.sprite = theme.armored;
        doubleScoreImage.sprite = theme.doubleScore;
        scoreImage.sprite = theme.score;

        nameText.text = theme.name;
        descriptionText.text = theme.description;

        buyText.text = theme.buyed ? "Equip" : theme.cost.ToString();
    }
}
