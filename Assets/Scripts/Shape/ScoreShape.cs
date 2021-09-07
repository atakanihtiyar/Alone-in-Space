using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreShape : Shape
{
    private GameObject particleEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterMovement characterMovement = collision.GetComponent<CharacterMovement>();
        if (characterMovement.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(1);
            Destroy(Instantiate(particleEffect, transform.position, Quaternion.identity), 1f);
        }
    }
}
