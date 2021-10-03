using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to create new state classes
/// </summary>
public abstract class GameBaseState
{
    public abstract void EnterState(GameStateController stateController);
    public abstract void Update(GameStateController stateController);
}
