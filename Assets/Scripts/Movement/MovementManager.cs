using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : Singleton<MovementManager>
{
    [SerializeField] private Vector2 movementDirectionVector;

    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float acceleration;

    public float Speed { get => speed; set { if (maxSpeed > speed) speed = value; } }
    public Vector2 MovementDirectionVector { get => movementDirectionVector; set => movementDirectionVector = value; }

    private void Start()
    {
        SpeedUp();
    }

    public void ChangeDirection()
    {
        MovementDirectionVector = new Vector2(-MovementDirectionVector.x, MovementDirectionVector.y);
    }

    public Vector2 GetVelocity()
    {
        return MovementDirectionVector.normalized * Speed;
    }

    public void SpeedUp()
    {
        if (Speed < maxSpeed)
        {
            Speed += acceleration * Time.deltaTime;
        }
    }
}
