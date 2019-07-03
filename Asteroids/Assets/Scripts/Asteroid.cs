using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 5f;
    private Movement movement;
    private IMovementDirectionHandler movementDirectionHandler;
    Vector2 movementDirection;

    public static event System.Action<Asteroid> AsteroidDestroyed;

    public void Init(Vector2 initialPosition)
    {
        movementDirectionHandler = new AsteroidMovementDirectionHandler();
        movementDirection = movementDirectionHandler.GetMovementDirection();
        movement = GetComponent<Movement>();
        movement.Init(movementSpeed, initialPosition);
    }

    public void Move(float deltaTime)
    {
        movement.MoveRigidbody(movementDirection, deltaTime);
    }
}
