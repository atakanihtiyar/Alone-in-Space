using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Props that can be collide with player
/// </summary>
public class Shape : UpgradedMonoBehaviour
{
    private Pattern pattern;
    [SerializeField] private GameObject particleEffect;

    private void Start()
    {
        pattern = GetComponentInParent<Pattern>();
    }

    private void Update()
    {
        // This will ensure that unity does not collide detection for this object. So it will create a slightly increase in performance
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

    private void Deactive()
    {
        pattern.deactivatedShapes.Add(this);
        gameObject.SetActive(false);
    }
}
