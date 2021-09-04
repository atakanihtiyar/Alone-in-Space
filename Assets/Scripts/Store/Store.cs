using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    private List<StoreItem> storeItems;
    private ThemeManager themeManager;
    public GameObject itemPrefab;
    public GameObject scrollViewContent;
    public Text coinText;

    private int totalCoin;

    private void Awake()
    {
        storeItems = new List<StoreItem>();
        themeManager = ThemeManager.instance;
    }

    private void OnEnable()
    {
        totalCoin = PlayerPrefs.GetInt("totalCoin");
        coinText.text = totalCoin.ToString();
        CreateStoreItems();
    }

    private void OnDisable()
    {
        ClearStoreItems();
    }

    public void CreateStoreItems()
    {
        for (int i = 0; i < themeManager.themes.Count; i++)
        {
            storeItems.Add(Instantiate(itemPrefab, scrollViewContent.transform).GetComponent<StoreItem>());
            storeItems[i].SetItemInfo(themeManager.themes[i], totalCoin);
        }
    }

    public void ClearStoreItems()
    {
        storeItems.ForEach(item => { Destroy(item.gameObject); });
        storeItems.Clear();
    }
}
