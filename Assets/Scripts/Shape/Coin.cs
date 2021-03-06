using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Shape
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        base.OnTriggerEnter2D(collision);

        coinController.AddToTempCoin(1);
    }
}
