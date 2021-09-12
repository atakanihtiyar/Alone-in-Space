using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : UpgradedMonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject playTimeInfoPanel;
    public GameObject playAreaPanel;
    public GameObject pausePanel;
    public GameObject storePanel;
    public GameObject gameOverPanel;

    public void PlayPattern()
    {
        mainMenuPanel.SetActive(false);
        playTimeInfoPanel.SetActive(true);
        gameStateController.TransitionToState(gameStateController.PlayState);
    }

    public void Pause()
    {
        gameStateController.TransitionToState(gameStateController.PauseState);
        pausePanel.SetActive(true);
    }

    public void Resume()
    {
        gameStateController.TransitionToState(gameStateController.PlayState);
        pausePanel.SetActive(false);
    }

    public void Quit()
    {
        gameStateController.GameQuit();
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        gameStateController.Restart();
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
        notify.Show("Tap for change direction\n" + 
            "Don't hit meteors(red)\n" + 
            "Collect coins(yellow) and double coin(blue)", Color.blue, Color.white, 5f);
    }
}
