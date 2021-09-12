using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : UpgradedMonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private Renderer myRenderer;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        Scroll();
    }

    private void Scroll()
    {
        if (transform.position.y > -myRenderer.bounds.size.y)
        {
            myRigidbody.velocity = new Vector2(0, movementManager.GetVelocity().y * 0.7f);
        }
        else
        {
            Vector2 offset = new Vector2(0, (myRenderer.bounds.size.y * 2));
            transform.position += (Vector3)offset;
        }
    }
}
