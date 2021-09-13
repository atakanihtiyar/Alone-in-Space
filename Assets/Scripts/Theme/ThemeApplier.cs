using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Abstract class for visualize theme parts
/// </summary>
public abstract class ThemeApplier : UpgradedMonoBehaviour
{
    /// <summary>
    /// Key for the theme part to be visualize
    /// </summary>
    [SerializeField] protected string key;

    protected virtual void OnEnable()
    {
        themeManager.ThemeChanged += SetTheme;
        SetTheme();
    }

    protected virtual void OnDisable()
    {
        themeManager.ThemeChanged -= SetTheme;
    }

    /// <summary>
    /// Visualize the theme part
    /// </summary>
    protected virtual void SetTheme()
    {

    }
}
