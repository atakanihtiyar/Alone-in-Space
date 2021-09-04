using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject playTimeInfoPanel;
    public GameObject playAreaPanel;
    public GameObject pausePanel;
    public GameObject storePanel;
    public GameObject gameOverPanel;

    public Text scoreTextPTIP;
    public Text scoreTextGOP;
    public Text coinText;

    public GameObject warningPanel;
    public Text warningText;
    private Coroutine warningCo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Int32.Parse(scoreTextPTIP.text) != GameManager.instance.totalScore &&
            GameManager.instance.currentGameState == GameState.PlayAbsoluteRandom || GameManager.instance.currentGameState == GameState.PlayPattern)
        {
            scoreTextPTIP.text = GameManager.instance.totalScore.ToString();
        }
    }

    public void PlayAbsoluteRandom()
    {
        mainMenuPanel.SetActive(false);
        playTimeInfoPanel.SetActive(true);
        GameManager.instance.PlayAbsoluteRandom();
    }

    public void PlayPattern()
    {
        mainMenuPanel.SetActive(false);
        playTimeInfoPanel.SetActive(true);
        GameManager.instance.PlayPattern();
    }

    public void Pause()
    {
        GameManager.instance.GamePause();
        pausePanel.SetActive(true);
    }

    public void Resume()
    {
        GameManager.instance.GameResume();
        pausePanel.SetActive(false);
    }

    public void Quit()
    {
        GameManager.instance.GameQuit();
    }

    public void GameOver(int coin, int score)
    {
        coinText.text = "Your Total Coin: " + coin;
        scoreTextGOP.text = "You Collected Coin: " + score;
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        GameManager.instance.Restart();
    }

    public void OpenStore()
    {
        storePanel.SetActive(true);
    }

    public void CloseStore()
    {
        storePanel.SetActive(false);
    }

    public void ShowWarning(string message, float waitTime)
    {
        if (warningCo != null)
            StopCoroutine(warningCo);

        warningPanel.SetActive(false);
        warningCo = StartCoroutine(Warning(message, waitTime));
    }

    public IEnumerator Warning(string message, float waitTime)
    {
        warningText.text = message;
        warningPanel.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        warningPanel.SetActive(false);
    }

    public void HowToWarning()
    {
        ShowWarning("Tap for change direction\nDon't hit meteors(red)\nCollect coins(yellow) and double coin(blue)", 5f);
    }
}
