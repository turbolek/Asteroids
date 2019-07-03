using UnityEngine;
using System.Collections;

public class AsteroidMovementDirectionHandler : IMovementDirectionHandler
{
    private Vector2 initialDirection;

    public AsteroidMovementDirectionHandler()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);
        initialDirection = new Vector2(randomX, randomY);
    }

    public Vector2 GetMovementDirection()
    {
        return initialDirection;
    }

    public Vector3 GetRotationDirection()
    {
        return Vector3.zero;
    }
}
