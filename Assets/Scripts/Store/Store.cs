using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class for creating and managing <c>StoreItem</c>
/// </summary>
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
        for (int i = 0; i < themeManager.themes.Count; i++)
        {
            storeItems.Add(Instantiate(itemPrefab, scrollViewContent.transform).GetComponent<StoreItem>());
            storeItems[i].SetItemInfo(themeManager.themes[i]);
        }
    }

    private void ClearStoreItems()
    {
        storeItems.ForEach(item => { Destroy(item.gameObject); });
        storeItems.Clear();
    }
}
