using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : UpgradedMonoBehaviour
{
    private List<StoreItem> storeItems;
    public GameObject itemPrefab;
    public GameObject scrollViewContent;

    private void Awake()
    {
        storeItems = new List<StoreItem>();
        themeManager = ThemeManager.Instance;
    }

    private void OnEnable()
    {
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
            storeItems[i].SetItemInfo(themeManager.themes[i]);
        }
    }

    public void ClearStoreItems()
    {
        storeItems.ForEach(item => { Destroy(item.gameObject); });
        storeItems.Clear();
    }
}
