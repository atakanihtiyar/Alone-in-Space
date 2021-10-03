using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy shape
/// </summary>
public class Armored : Shape
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        base.OnTriggerEnter2D(collision);

        gameStateController.TransitionToState(gameStateController.OverState);
    }
}
