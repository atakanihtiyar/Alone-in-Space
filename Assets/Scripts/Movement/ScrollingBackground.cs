using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : UpgradedMonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private Renderer myRenderer;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        Scroll();
    }

    public void Scroll()
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
