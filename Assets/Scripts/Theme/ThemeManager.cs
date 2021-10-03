using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeManager : Singleton<ThemeManager>
{
    public delegate void OnThemeChanged();
    public OnThemeChanged ThemeChanged;

    private int currentTheme;
    [SerializeField] private List<Theme> themes;

    private void Start()
    {
        currentTheme = PlayerPrefs.GetInt("theme", 0);
    }

    public void BuyTheme(Theme themeToBuy)
    {
        currentTheme = themes.IndexOf(themeToBuy);
        themes[currentTheme].buyed = true;
        PlayerPrefs.SetInt("theme", currentTheme);
        ThemeChanged?.Invoke();
    }

    public void EquipTheme(Theme themeToEquip)
    {
        currentTheme = themes.IndexOf(themeToEquip);
        PlayerPrefs.SetInt("theme", currentTheme);
        ThemeChanged?.Invoke();
    }

    public Theme GetTheme()
    {
        return themes[currentTheme];
    }

    public Theme GetThemeByIndex(int index)
    {
        return themes[index];
    }

    public int GetThemeCount()
    {
        return themes.Count;
    }
}
