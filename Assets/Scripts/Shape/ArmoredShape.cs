using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmoredShape : Shape
{
    private GameObject particleEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterMovement characterMovement = collision.GetComponent<CharacterMovement>();
        if (characterMovement.CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
            Destroy(characterMovement.gameObject);
            Destroy(Instantiate(particleEffect, transform.position, Quaternion.identity), 1f);
        }
    }
}
