using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : GameBaseState
{
    public override void EnterState(GameStateController stateController)
    {
        MovementManager.Instance.Speed = 0;
        stateController.spawner.SetActive(false);
        stateController.canvas.GameOver();
        CoinController.Instance.TransferTempToTotal();
    }

    public override void Update(GameStateController stateController)
    {

    }
}