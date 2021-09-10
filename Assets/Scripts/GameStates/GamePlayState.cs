using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : GameBaseState
{
    public override void EnterState(GameStateController stateController)
    {
        Time.timeScale = 1f;
        MovementManager.Instance.SpeedUp();
    }

    public override void Update(GameStateController stateController)
    {
        MovementManager.Instance.SpeedUp();
    }
}
