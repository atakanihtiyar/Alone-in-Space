using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class for visualize theme parts on <c>Image</c> component
/// </summary>
[RequireComponent(typeof(Image))]
public class ThemeApplierImage : ThemeApplier
{
    private Image _image;

    protected override void OnEnable()
    {
        _image = GetComponent<Image>();
        base.OnEnable();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }

    protected override void SetTheme()
    {
        Theme currentTheme = themeManager.GetTheme();
        _image.sprite = currentTheme.GetThemePart(key).sprite;
    }
}
