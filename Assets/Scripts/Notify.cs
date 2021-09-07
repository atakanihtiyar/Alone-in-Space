using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notify : Singleton<Notify>
{
    private Text notifyText;
    private Coroutine notifyCoroutine;

    private void OnEnable()
    {
        notifyText = GetComponentInChildren<Text>();
    }

    public void Show(string message, float waitTime)
    {
        if (notifyCoroutine != null)
            StopCoroutine(notifyCoroutine);

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
