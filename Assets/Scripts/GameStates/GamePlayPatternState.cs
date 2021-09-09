using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayPatternState : GameBaseState
{
    public override void EnterState(GameStateController stateController)
    {
        Time.timeScale = 1f;
        stateController.SpeedUp();

        //SpawnerPattern spawner = new GameObject("patternSpawner").AddComponent<SpawnerPattern>();
    }

    public override void Update(GameStateController stateController)
    {
        stateController.SpeedUp();
    }
}