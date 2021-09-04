using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeManager : MonoBehaviour
{
    public static ThemeManager instance;
    public CanvasManager canvas;

    public Theme currentTheme;
    public Theme[] themes;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        int curThemeInt = PlayerPrefs.GetInt("theme", 0);
        PickTheme(curThemeInt);
    }

    public void BuyTheme(string name)
    {
        canvas.ShowWarning("You must restart the game for apply to change", 3f);
        int totalCoin = PlayerPrefs.GetInt("totalCoin");
        for (int i = 0; i < themes.Length; i++)
        {
            if (themes[i].name == name)
            {
                if (!themes[i].buyed)
                {
                    if (totalCoin >= themes[i].cost)
                    {
                        PlayerPrefs.SetInt("theme", i);
                        PickTheme(i);
                        PlayerPrefs.SetInt("totalCoin", totalCoin - themes[i].cost);
                        themes[i].buyed = true;
                        canvas.ShowWarning("You must restart the game for apply to change", 3f);
                    }
                    else
                    {
                        canvas.ShowWarning("You have no money!", 3f);
                    }

                }
                else if(themes[i].buyed)
                {
                    PlayerPrefs.SetInt("theme", i);
                    PickTheme(i);
                    canvas.ShowWarning("You must restart the game for apply to change", 3f);
                }
            }
        }
    }

    public void PickTheme(int i)
    {
        currentTheme.none = themes[i].none;

        currentTheme.description = themes[i].description;
        currentTheme.cost = themes[i].cost;
        currentTheme.buyed = themes[i].buyed;

        currentTheme.background = themes[i].background;
        currentTheme.ship = themes[i].ship;

        currentTheme.armored = themes[i].armored;
        currentTheme.doubleScore = themes[i].doubleScore;
        currentTheme.score = themes[i].score;
    }
}
