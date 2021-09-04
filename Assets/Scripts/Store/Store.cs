using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    private ThemeManager themeManager;
    public GameObject itemPrefab;
    public GameObject scrollViewContent;
    public Text coinText;

    private int totalCoin;

    private void Start()
    {
        themeManager = ThemeManager.instance;

        CreateStoreItems();
    }
    
    void Update()
    {
        if (Int32.Parse(coinText.text) != PlayerPrefs.GetInt("totalCoin"))
        {
            coinText.text = "" + PlayerPrefs.GetInt("totalCoin");
        }
    }

    public void CreateStoreItems()
    {
        for (int i = 0; i < themeManager.themes.Length; i++)
        {

            GameObject item = Instantiate(itemPrefab, scrollViewContent.transform);
            item.transform.Find("BackgroundImage").GetComponent<Image>().sprite = themeManager.themes[i].background;
            item.transform.Find("ArmoredImage").GetComponent<Image>().sprite = themeManager.themes[i].armored;
            item.transform.Find("DoubleScoreImage").GetComponent<Image>().sprite = themeManager.themes[i].doubleScore;
            item.transform.Find("ScoreImage").GetComponent<Image>().sprite = themeManager.themes[i].score;

            item.transform.Find("NameText").GetComponent<Text>().text = themeManager.themes[i].name;
            item.transform.Find("DescriptionText").GetComponent<Text>().text = themeManager.themes[i].description;

            if (!themeManager.themes[i].buyed)
                item.transform.Find("BuyButton").Find("CostText").GetComponent<Text>().text = "" + themeManager.themes[i].cost;
            else
            {
                if (themeManager.currentTheme.name == themeManager.themes[i].name)
                {
                    //when use it
                    item.transform.Find("BuyButton").Find("CostText").GetComponent<Text>().text = "Equip";
                }
                else
                {
                    //when not use it
                    item.transform.Find("BuyButton").Find("CostText").GetComponent<Text>().text = "Equip";
                }
            }
        }
    }
}
