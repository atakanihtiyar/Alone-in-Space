using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : Singleton<MovementManager>
{
    public Vector2 movementDirectionVector;

    public float speedMultiplier;
    public float maxSpeedMultiplier;
    public float acceleration;

    private void Start()
    {
        SpeedUp();
    }

    public void ChangeDirection()
    {
        movementDirectionVector = new Vector2(-movementDirectionVector.x, movementDirectionVector.y);
    }

    public Vector2 GetVelocity()
    {
        return movementDirectionVector.normalized* speedMultiplier;
    }

    public void SpeedUp()
    {
        if (speedMultiplier < maxSpeedMultiplier)
        {
            speedMultiplier += acceleration * Time.deltaTime;
        }
    }
}
