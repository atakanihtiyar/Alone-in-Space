using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Singleton class for managing game state changes
/// </summary>
public class GameStateController : Singleton<GameStateController>
{
    private GameBaseState CurrentState { get; set; }

    /// <summary>
    /// Play state as a class
    /// </summary>
    public readonly GamePlayState PlayState = new GamePlayState();
    /// <summary>
    /// Pause state as a class
    /// </summary>
    public readonly GamePauseState PauseState = new GamePauseState();
    /// <summary>
    /// Game over state as a class
    /// </summary>
    public readonly GameOverState OverState = new GameOverState();

    /// <summary>
    /// Reference to main canvas script
    /// </summary>
    public CanvasManager canvas;
    /// <summary>
    /// Reference to spawner object
    /// </summary>
    public GameObject spawner;

    private void Start()
    {
        TransitionToState(PauseState);
    }

    private void Update()
    {
        CurrentState.Update(this);
    }

    /// <summary>
    /// This method is used to switch between states
    /// </summary>
    /// <param name="state">New state to switch</param>
    public void TransitionToState(GameBaseState state)
    {
        CurrentState = state;
        CurrentState.EnterState(this);
    }

    /// <summary>
    /// Closes the game
    /// </summary>
    public void GameQuit()
    {
        Application.Quit();
    }

    /// <summary>
    /// Restarts the game
    /// </summary>
    public void Restart()
    {
        TransitionToState(PlayState);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
