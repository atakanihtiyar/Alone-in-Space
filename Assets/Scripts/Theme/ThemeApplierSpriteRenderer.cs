using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ThemeApplierSpriteRenderer : ThemeApplier
{
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
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
        _spriteRenderer.sprite = currentTheme.GetThemePart(key).sprite;
    }
}
