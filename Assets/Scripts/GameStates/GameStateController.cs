using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : Singleton<GameStateController>
{
    private GameBaseState CurrentState { get; set; }

    public readonly GamePlayState PlayState = new GamePlayState();
    public readonly GamePauseState PauseState = new GamePauseState();
    public readonly GameOverState OverState = new GameOverState();

    public CanvasManager canvas;
    public Spawner spawner;

    private void Start()
    {
        TransitionToState(PauseState);
    }

    private void Update()
    {
        CurrentState.Update(this);
    }

    /// <summary>
    /// For changing state
    /// </summary>
    public void TransitionToState(GameBaseState newState)
    {
        CurrentState = newState;
        CurrentState.EnterState(this);
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        TransitionToState(PlayState);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
