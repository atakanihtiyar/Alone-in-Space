using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    none,
    PlayAbsoluteRandom,
    PlayPattern,
    gamePaused,
    gameOver,
    mainMenu
}

public class GameManager : Singleton<GameManager>
{
    public CanvasManager canvas;

    public GameState currentGameState;
    private GameState lastState;

    public bool isGoingRight = true;
    public Vector2 movementDirectionVector;
    public Vector2 velocity;
    public float speedMultiple;
    public float maxSpeed;
    public float acceleration;

    private Vector2 touchOrigin = -Vector2.one;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();

        currentGameState = GameState.mainMenu;
        SpeedUp();

        Application.targetFrameRate = 30;
    }

    void LateUpdate()
    {
        if (currentGameState == GameState.PlayAbsoluteRandom || currentGameState == GameState.PlayPattern)
        {
            SpeedUp();
        }
    }

    public Vector2 GetVelocity()
    {
        return velocity;
    }

    public void ChangeDirection()
    {
        if (isGoingRight)
        {
            movementDirectionVector = new Vector2(-movementDirectionVector.x, movementDirectionVector.y);
            isGoingRight = false;
        }
        else
        {
            movementDirectionVector = new Vector2(-movementDirectionVector.x, movementDirectionVector.y);
            isGoingRight = true;
        }
    }

    public void SpeedUp()
    {
        velocity = movementDirectionVector.normalized * speedMultiple;
        if (speedMultiple < maxSpeed)
            speedMultiple += acceleration * Time.deltaTime;
    }

    public void GameOver()
    {
        speedMultiple = 0;
        canvas.GameOver();
        CoinController.Instance.GameOver();
        currentGameState = GameState.gameOver;
    }
    
    public void PlayAbsoluteRandom()
    {
        currentGameState = GameState.PlayAbsoluteRandom;
    }

    public void PlayPattern()
    {
        currentGameState = GameState.PlayPattern;
    }

    public void GamePause()
    {
        lastState = currentGameState;
        currentGameState = GameState.gamePaused;
        Time.timeScale = 0f;
    }

    public void GameResume()
    {
        currentGameState = lastState;
        Time.timeScale = 1f;
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        GameResume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
