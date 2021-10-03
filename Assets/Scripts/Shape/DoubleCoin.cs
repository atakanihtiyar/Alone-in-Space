using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Power up shape
/// </summary>
public class DoubleCoin : Shape
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        base.OnTriggerEnter2D(collision);
    }
}
