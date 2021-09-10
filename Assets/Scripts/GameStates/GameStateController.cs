using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : Singleton<GameStateController>
{
    public GameBaseState CurrentState { get; private set; }

    public readonly GamePlayState PlayState = new GamePlayState();
    public readonly GamePauseState PauseState = new GamePauseState();
    public readonly GameOverState OverState = new GameOverState();

    public CanvasManager canvas;

    private void Start()
    {
        TransitionToState(PauseState);
    }
     
    private void Update()
    {
        CurrentState.Update(this);
    }

    public void TransitionToState(GameBaseState state)
    {
        CurrentState = state;
        CurrentState.EnterState(this);
    }

    public void Play()
    {
        TransitionToState(PlayState);
    }

    public void Pause()
    {
        TransitionToState(PauseState);
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
