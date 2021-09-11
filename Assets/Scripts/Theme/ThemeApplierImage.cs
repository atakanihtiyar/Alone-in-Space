using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ThemeApplierImage : ThemeApplier
{
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    protected override void OnEnable()
    {
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
