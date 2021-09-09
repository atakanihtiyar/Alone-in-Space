using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notify : Singleton<Notify>
{
    public Image backgroundImage;
    public Text notifyText;

    private Coroutine hideCoroutine;

    protected override void Awake()
    {
        base.Awake();
        GetComponent<CanvasGroup>().alpha = 1;
        gameObject.SetActive(false);
    }

    public void Show(string message, Color backgroundColor, Color textColor, float waitTime)
    {
        backgroundImage = GetComponent<Image>();
        backgroundImage.color = backgroundColor;

        notifyText = GetComponentInChildren<Text>();
        notifyText.text = message;
        notifyText.color = textColor;

        gameObject.SetActive(true);

        if (hideCoroutine != null)
            StopCoroutine(hideCoroutine);

        StartCoroutine(Hide(waitTime));
    }

    private IEnumerator Hide(float waitTime)
    {
        yield return new WaitForSecondsRealtime(waitTime);

        notifyText.text = "";
        gameObject.SetActive(false);
    }
}
