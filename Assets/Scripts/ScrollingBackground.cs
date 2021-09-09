using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private GameStateController gameStateController;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        gameStateController = GameStateController.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }

    public void Scroll()
    {
        Renderer myRenderer = GetComponent<Renderer>();
        //if my y is bigger than my size y
        if (transform.position.y > -myRenderer.bounds.size.y)
        {
            //just slide down
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, gameStateController.Velocity.y);
        }
        else
        {
            //put me 2x my size up
            Vector2 edgeOffset = new Vector2(0, (myRenderer.bounds.size.y * 2));
            transform.position = (Vector2)transform.position - new Vector2(0, 0.2f) + edgeOffset;
        }
    }
}
