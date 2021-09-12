using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : GameBaseState
{
    public override void EnterState(GameStateController stateController)
    {
        MovementManager.Instance.speedMultiplier = 0;
        stateController.canvas.GameOver();
        CoinController.Instance.TransferTempToTotal();
    }

    public override void Update(GameStateController stateController)
    {

    }
}