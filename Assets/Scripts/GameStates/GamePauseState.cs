using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseState : GameBaseState
{
    public override void EnterState(GameStateController stateController)
    {
        Time.timeScale = 0f;
        stateController.spawner.SetActive(false);
    }

    public override void Update(GameStateController stateController)
    {

    }
}
