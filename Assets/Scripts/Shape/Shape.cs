using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    public void ReactivateShape()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        Pattern pattern = GetComponentInParent<Pattern>();
        pattern.deactivatedShapes.Add(gameObject);
        gameObject.SetActive(false);
    }
}
