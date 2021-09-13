using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseState : GameBaseState
{
    public override void EnterState(GameStateController stateController)
    {
        Time.timeScale = 0f;

        // if deactivated without checking, ienumerator throws null reference error 
        if (!stateController.spawner.isCreatingContinue)
            stateController.spawner.gameObject.SetActive(false);
    }

    public override void Update(GameStateController stateController)
    {

    }
}
