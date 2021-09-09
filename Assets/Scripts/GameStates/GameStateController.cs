using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : Singleton<GameStateController>
{
    private GameBaseState currentState;

    public readonly GamePlayState PlayState = new GamePlayState();
    public readonly GamePauseState PauseState = new GamePauseState();

    private void Start()
    {
        TransitionToState(PauseState);
    }

    private void Update()
    {
        currentState.Update(this);
    }

    public void TransitionToState(GameBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
