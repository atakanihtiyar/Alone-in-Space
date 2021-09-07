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



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Int32.Parse(scoreTextPTIP.text) != GameManager.Instance.totalScore &&
            GameManager.Instance.currentGameState == GameState.PlayAbsoluteRandom || GameManager.Instance.currentGameState == GameState.PlayPattern)
        {
            scoreTextPTIP.text = GameManager.Instance.totalScore.ToString();
        }
    }

    public void PlayAbsoluteRandom()
    {
        mainMenuPanel.SetActive(false);
        playTimeInfoPanel.SetActive(true);
        GameManager.Instance.PlayAbsoluteRandom();
    }

    public void PlayPattern()
    {
        mainMenuPanel.SetActive(false);
        playTimeInfoPanel.SetActive(true);
        GameManager.Instance.PlayPattern();
    }

    public void Pause()
    {
        GameManager.Instance.GamePause();
        pausePanel.SetActive(true);
    }

    public void Resume()
    {
        GameManager.Instance.GameResume();
        pausePanel.SetActive(false);
    }

    public void Quit()
    {
        GameManager.Instance.GameQuit();
    }

    public void GameOver(int coin, int score)
    {
        coinText.text = "Your Total Coin: " + coin;
        scoreTextGOP.text = "You Collected Coin: " + score;
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        GameManager.Instance.Restart();
    }

    public void OpenStore()
    {
        storePanel.SetActive(true);
    }

    public void CloseStore()
    {
        storePanel.SetActive(false);
    }

    public void HowToNotify()
    {
        Notify.Instance.Show("Tap for change direction\n" + 
            "Don't hit meteors(red)\n" + 
            "Collect coins(yellow) and double coin(blue)", Color.blue, Color.white, 5f);
    }
}
