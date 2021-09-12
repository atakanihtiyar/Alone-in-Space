using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base abstract class to create new state classes
/// </summary>
public abstract class GameBaseState
{
    /// <summary>
    /// Function that should run on first pass to State 
    /// </summary>
    /// <param name="stateController">Controller that manages all states</param>
    public abstract void EnterState(GameStateController stateController);
    /// <summary>
    /// Function that should run on every update
    /// </summary>
    /// <param name="stateController">Controller that manages all states</param>
    public abstract void Update(GameStateController stateController);
}
