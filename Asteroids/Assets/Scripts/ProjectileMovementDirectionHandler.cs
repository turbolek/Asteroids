using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovementDirectionHandler : IMovementDirectionHandler
{
    private Transform transform;

    public ProjectileMovementDirectionHandler(Transform transform)
    {
        this.transform = transform;
    }

    public Vector2 GetMovementDirection()
    {
        return transform.up;
    }

    public Vector3 GetRotationDirection()
    {
        return Vector3.zero;
    }
}
