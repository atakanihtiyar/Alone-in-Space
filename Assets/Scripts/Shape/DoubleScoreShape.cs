using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleScoreShape : Shape
{
    private GameObject particleEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterMovement characterMovement = collision.GetComponent<CharacterMovement>();
        if (characterMovement.CompareTag("Player"))
        {
            StartCoroutine(characterMovement.DoubleScored());
            Destroy(Instantiate(particleEffect, transform.position, Quaternion.identity), 1f);
        }
    }
}
