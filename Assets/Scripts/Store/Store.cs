using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : UpgradedMonoBehaviour
{
    private List<StoreItem> storeItems;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private GameObject scrollViewContent;

    private void OnEnable()
    {
        storeItems = new List<StoreItem>();
        CreateStoreItems();
    }

    private void OnDisable()
    {
        ClearStoreItems();
    }

    private void CreateStoreItems()
    {
        for (int i = 0; i < themeManager.GetThemeCount(); i++)
        {
            storeItems.Add(Instantiate(itemPrefab, scrollViewContent.transform).GetComponent<StoreItem>());
            storeItems[i].SetItemInfo(themeManager.GetThemeByIndex(i));
        }
    }

    private void ClearStoreItems()
    {
        storeItems.ForEach(item => { Destroy(item.gameObject); });
        storeItems.Clear();
    }
}
