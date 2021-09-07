using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notify : Singleton<Notify>
{
    private Text notifyText;

    private void OnEnable()
    {
        notifyText = GetComponentInChildren<Text>();
    }

    public void Show(string message, float waitTime)
    {
        gameObject.SetActive(true);
        notifyText.text = message;
        Invoke("Hide", waitTime);
    }

    private void Hide()
    {
        notifyText.text = "";
        gameObject.SetActive(false);
    }
}
