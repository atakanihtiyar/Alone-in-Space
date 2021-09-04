using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ThemeKey
{
    none,
    background,
    ship,
    armored,
    doubleScore,
    score,
    uiScore
}

public class ThemeApplier : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;

    public ThemeKey key;
    public Theme currentTheme;

    // Start is called before the first frame update
    void Start()
    {
        if (key != ThemeKey.uiScore)
            mySpriteRenderer = GetComponent<SpriteRenderer>();

        SetTheme();
    }

    public void SetTheme()
    {
        currentTheme = ThemeManager.instance.GetTheme();
        switch (key)
        {
            case ThemeKey.background:
                mySpriteRenderer.sprite = currentTheme.background;
                break;
            case ThemeKey.armored:
                mySpriteRenderer.sprite = currentTheme.armored;
                break;
            case ThemeKey.doubleScore:
                mySpriteRenderer.sprite = currentTheme.doubleScore;
                break;
            case ThemeKey.score:
                mySpriteRenderer.sprite = currentTheme.score;
                break;
            case ThemeKey.uiScore:
                GetComponent<Image>().sprite = currentTheme.score;
                break;
            default:
                mySpriteRenderer.sprite = currentTheme.none;
                break;
        }
    }
}
