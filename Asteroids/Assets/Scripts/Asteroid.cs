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
    private bool initialized = false;

    public static event System.Action<Asteroid> AsteroidDestroyed;

    public void Init(Vector2 initialPosition)
    {
        if (!initialized)
        {
            movementDirectionHandler = new AsteroidMovementDirectionHandler();
            movement = GetComponent<Movement>();
        }

        movementDirection = movementDirectionHandler.GetMovementDirection();
        movement.Init(movementSpeed, initialPosition);
    }

    public void Move(float deltaTime)
    {
        movement.MoveRigidbody(movementDirection, deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        AsteroidDestroyed(this);
    }

}
