using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreItem : MonoBehaviour
{
    public void BuyItem()
    {
        string myName = transform.Find("NameText").GetComponent<Text>().text;
        transform.Find("BuyButton").Find("CostText").GetComponent<Text>().text = "";

        ThemeManager.instance.BuyTheme(myName);
    }
}
