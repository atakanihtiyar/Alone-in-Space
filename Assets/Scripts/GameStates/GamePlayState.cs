using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : GameBaseState
{
    public override void EnterState(GameStateController stateController)
    {
        Time.timeScale = 1f;
        stateController.SpeedUp();
    }

    public override void Update(GameStateController stateController)
    {
        stateController.SpeedUp();
    }
}
