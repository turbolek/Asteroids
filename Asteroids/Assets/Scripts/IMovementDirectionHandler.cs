using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementDirectionHandler
{
    Vector2 GetMovementDirection();
    Vector3 GetRotationDirection();
}
