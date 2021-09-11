using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : UpgradedMonoBehaviour
{
    public GameObject particleEffect;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        Pattern pattern = GetComponentInParent<Pattern>();
        pattern.deactivatedShapes.Add(this);
        gameObject.SetActive(false);
        Destroy(Instantiate(particleEffect, transform.position, Quaternion.identity), 1f);
    }
}
