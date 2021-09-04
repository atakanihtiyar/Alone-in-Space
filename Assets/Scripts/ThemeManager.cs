using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeManager : MonoBehaviour
{
    public static ThemeManager instance;
    public CanvasManager canvas;

    public int currentTheme;
    public Theme[] themes;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        currentTheme = PlayerPrefs.GetInt("theme", 0);
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
        currentTheme = i;
    }

    public Theme GetTheme()
    {
        return themes[currentTheme];
    }
}
