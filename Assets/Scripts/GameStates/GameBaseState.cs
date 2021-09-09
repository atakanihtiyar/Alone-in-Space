using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameBaseState
{
    public abstract void EnterState(GameStateController stateController);
    public abstract void Update(GameStateController stateController);
}
