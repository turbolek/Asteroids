using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed;
    private Transform cachedTransform;
    private Vector2 currentPosition;
    private Vector2 newPosition;
    private Rigidbody2D rBody2D;

    public float Speed
    {
        get { return speed; }
    }

    public void Init(float speed, Vector2 initialPosition)
    {
        this.speed = speed;
        cachedTransform = transform;
        currentPosition = initialPosition;
        newPosition = currentPosition;
        MoveToPosition(currentPosition);
        rBody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 direction, float deltaTime)
    {
        newPosition.x = currentPosition.x + direction.x * speed * deltaTime;
        newPosition.y = currentPosition.y + direction.y * speed * deltaTime;
        MoveToPosition(newPosition);
    }

    public void MoveToPosition(Vector2 position)
    {
        cachedTransform.position = position;
        currentPosition = position;
    }

    public void MoveRigidbody(Vector2 direction, float deltaTime)
    {
        UnityEngine.Profiling.Profiler.BeginSample("calculations");
        newPosition.x = currentPosition.x + direction.x * speed * deltaTime;
        newPosition.y = currentPosition.y + direction.y * speed * deltaTime;
        UnityEngine.Profiling.Profiler.EndSample();

        currentPosition = newPosition;
        rBody2D.position = newPosition;
    }
}
