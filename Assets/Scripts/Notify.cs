using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notify : Singleton<Notify>
{
    public Image backgroundImage;
    public Text notifyText;

    public void Show(string message, Color backgroundColor, Color textColor, float waitTime)
    {
        backgroundImage = GetComponent<Image>();
        backgroundImage.color = backgroundColor;

        notifyText = GetComponentInChildren<Text>();
        notifyText.text = message;
        notifyText.color = textColor;

        gameObject.SetActive(true);

        Invoke("Hide", waitTime);
    }

    private void Hide()
    {
        notifyText.text = "";
        gameObject.SetActive(false);
    }
}
