using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ThemeApplier : UpgradedMonoBehaviour
{
    public string key;

    protected virtual void OnEnable()
    {
        themeManager.ThemeChanged += SetTheme;
        SetTheme();
    }

    protected virtual void OnDisable()
    {
        themeManager.ThemeChanged -= SetTheme;
    }

    protected virtual void SetTheme()
    {

    }
}
