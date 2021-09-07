using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeManager : Singleton<ThemeManager>
{
    public CanvasManager canvas;

    public int currentTheme;
    public List<Theme> themes;

    void Awake()
    {
        currentTheme = PlayerPrefs.GetInt("theme", 0);
    }

    public void BuyTheme(Theme themeToBuy)
    {
        int totalCoin = PlayerPrefs.GetInt("totalCoin");
        PlayerPrefs.SetInt("totalCoin", totalCoin - themes[currentTheme].cost);

        currentTheme = themes.IndexOf(themeToBuy);
        themes[currentTheme].buyed = true;
        PlayerPrefs.SetInt("theme", currentTheme);

        Notify.Instance.Show("You must restart the game for apply to change", Color.red, Color.white, 3f);
    }

    internal void EquipTheme(Theme themeToEquip)
    {
        currentTheme = themes.IndexOf(themeToEquip);
        PlayerPrefs.SetInt("theme", currentTheme);

        Notify.Instance.Show("You must restart the game for apply to change", Color.red, Color.white, 3f);
    }

    public Theme GetTheme()
    {
        return themes[currentTheme];
    }
}
