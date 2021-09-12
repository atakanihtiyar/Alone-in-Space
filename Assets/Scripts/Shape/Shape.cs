﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : UpgradedMonoBehaviour
{
    private Pattern pattern;
    public GameObject particleEffect;

    public void Start()
    {
        pattern = GetComponentInParent<Pattern>();
    }

    public void Update()
    {
        if (!pattern.IsShowing())
        {
            Deactive();
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        Deactive();
        Destroy(Instantiate(particleEffect, transform.position, Quaternion.identity), 1f);
    }

    public void Deactive()
    {
        pattern.deactivatedShapes.Add(this);
        gameObject.SetActive(false);
    }
}
