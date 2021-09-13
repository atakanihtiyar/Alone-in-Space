using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : UpgradedMonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject playTimeInfoPanel;
    [SerializeField] private GameObject playAreaPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject gameOverPanel;

    public void Play()
    {
        gameStateController.TransitionToState(gameStateController.PlayState);
    }

    public void Pause()
    {
        gameStateController.TransitionToState(gameStateController.PauseState);
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        gameStateController.Restart();
    }

    public void HowToNotify()
    {
        notify.Show("Tap for change direction\n" + 
            "Don't hit meteors(red)\n" + 
            "Collect coins(yellow) and double coin(blue)", Color.blue, Color.white, 5f);
    }
}
