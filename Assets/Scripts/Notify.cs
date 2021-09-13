using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Singleton class for notify the player  
/// </summary>
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

    /// <summary>
    /// Function used to show a message to the player
    /// </summary>
    /// <param name="message">Message to visualize</param>
    /// <param name="backgroundColor">Color of notify panel</param>
    /// <param name="textColor">Color of notify text</param>
    /// <param name="waitTime">Time to display the panel</param>
    public void Show(string message, Color backgroundColor, Color textColor, float waitTime)
    {
        backgroundImage.color = backgroundColor;

        notifyText.text = message;
        notifyText.color = textColor;

        gameObject.SetActive(true);

        if (hideCoroutine != null)
            StopCoroutine(hideCoroutine);

        hideCoroutine = StartCoroutine(Hide(waitTime));
    }

    private IEnumerator Hide(float waitTime)
    {
        yield return new WaitForSecondsRealtime(waitTime);

        notifyText.text = "";
        gameObject.SetActive(false);
    }
}
