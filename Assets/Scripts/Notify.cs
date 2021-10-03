using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notify : Singleton<Notify>
{
    private Image backgroundImage;
    private Text notifyText;

    private Coroutine hideCoroutine;

    protected override void Awake()
    {
        base.Awake();
        GetComponent<CanvasGroup>().alpha = 1;
        gameObject.SetActive(false);

        backgroundImage = GetComponent<Image>();
        notifyText = GetComponentInChildren<Text>();
    }

    public void Show(string message, Color backgroundColor, Color textColor, float waitTime)
    {
        backgroundImage.color = backgroundColor;

        notifyText.text = message;
        notifyText.color = textColor;

        gameObject.SetActive(true);

        if (hideCoroutine != null)
            StopCoroutine(hideCoroutine);

        // Using coroutine provides wait time independent from scaled time instead of delayed invoke
        hideCoroutine = StartCoroutine(Hide(waitTime));
    }

    private IEnumerator Hide(float waitTime)
    {
        yield return new WaitForSecondsRealtime(waitTime);

        notifyText.text = "";
        gameObject.SetActive(false);
    }
}
