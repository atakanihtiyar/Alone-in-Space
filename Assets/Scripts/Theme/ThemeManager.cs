using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeManager : Singleton<ThemeManager>
{
    public delegate void OnThemeChanged();
    public OnThemeChanged ThemeChanged;

    public CanvasManager canvas;

    public int currentTheme;
    public List<Theme> themes;

    protected override void Awake()
    {
        base.Awake();
        currentTheme = PlayerPrefs.GetInt("theme", 0);
    }

    public void BuyTheme(Theme themeToBuy)
    {
        currentTheme = themes.IndexOf(themeToBuy);
        themes[currentTheme].buyed = true;
        PlayerPrefs.SetInt("theme", currentTheme);
        ThemeChanged?.Invoke();
    }

    internal void EquipTheme(Theme themeToEquip)
    {
        currentTheme = themes.IndexOf(themeToEquip);
        PlayerPrefs.SetInt("theme", currentTheme);
        ThemeChanged?.Invoke();
    }

    public Theme GetTheme()
    {
        return themes[currentTheme];
    }
}
