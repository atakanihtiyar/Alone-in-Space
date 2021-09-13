using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton class for managing movement
/// </summary>
public class MovementManager : Singleton<MovementManager>
{
    [SerializeField] private Vector2 movementDirectionVector;

    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float acceleration;

    /// <summary>
    /// Property for speed (Cannot be greater than maximum speed)
    /// </summary>
    public float Speed { get => speed; set { if (MaxSpeed > speed) speed = value; } }
    /// <summary>
    /// Property for movement direction
    /// </summary>
    public Vector2 MovementDirectionVector { get => movementDirectionVector;}
    /// <summary>
    /// Property for maximum speed
    /// </summary>
    public float MaxSpeed { get => maxSpeed; }

    private void Start()
    {
        SpeedUp();
    }

    /// <summary>
    /// Function for change direction on x axis
    /// </summary>
    public void ChangeXDirection()
    {
        movementDirectionVector = new Vector2(-movementDirectionVector.x, movementDirectionVector.y);
    }

    /// <summary>
    /// Function for get velocity
    /// </summary
    /// <returns>Velocity</returns>
    public Vector2 GetVelocity()
    {
        return MovementDirectionVector.normalized * Speed;
    }

    /// <summary>
    /// Function for speed up
    /// </summary>
    public void SpeedUp()
    {
        if (Speed < MaxSpeed)
        {
            Speed += acceleration * Time.deltaTime;
        }
    }
}
