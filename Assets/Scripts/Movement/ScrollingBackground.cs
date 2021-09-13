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
        if (IsShowing())
        {
            myRigidbody.velocity = new Vector2(0, movementManager.GetVelocity().y * 0.7f);
        }
        else
        {
            Vector2 offset = new Vector2(0, (myRenderer.bounds.size.y * 2));
            transform.position += (Vector3)offset;
        }
    }

    private bool IsShowing()
    {
        float minPosY = -myRenderer.bounds.size.y;

        if (transform.position.y > minPosY)
            return true;

        return false;
    }
}
