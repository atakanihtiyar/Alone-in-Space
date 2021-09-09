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
    public readonly GamePlayPatternState PlayPatternState = new GamePlayPatternState();

    public CanvasManager canvas;

    public Vector2 movementDirectionVector;
    public Vector2 Velocity;
    public float speedMultiplier;
    public float maxSpeed;
    public float acceleration;

    private void Start()
    {
        TransitionToState(PauseState);
        SpeedUp();
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

    public void ChangeDirection()
    {
        movementDirectionVector = new Vector2(-movementDirectionVector.x, movementDirectionVector.y);
    }

    public void SpeedUp()
    {
        if (speedMultiplier < maxSpeed)
        {
            speedMultiplier += acceleration * Time.deltaTime;
            Velocity = movementDirectionVector.normalized * speedMultiplier;
        }
    }

    public void Play()
    {
        TransitionToState(PlayState);
    }

    public void GamePause()
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
