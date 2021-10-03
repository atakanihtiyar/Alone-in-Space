using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : Singleton<MovementManager>
{
    [SerializeField] private Vector2 movementDirectionVector;

    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float acceleration;

    /// <summary>
    /// Speed cannot be greater than maximum speed
    /// </summary>
    public float Speed { get => speed; set { if (MaxSpeed > speed) speed = value; } }
    public Vector2 MovementDirection { get => movementDirectionVector;}
    public float MaxSpeed { get => maxSpeed; }

    private void Start()
    {
        SpeedUp();
    }

    public void ChangeXDirection()
    {
        movementDirectionVector = new Vector2(-movementDirectionVector.x, movementDirectionVector.y);
    }

    public Vector2 GetVelocity()
    {
        return MovementDirection.normalized * Speed;
    }

    public void SpeedUp()
    {
        Speed += acceleration * Time.deltaTime;
    }
}
