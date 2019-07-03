using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementDirectionGetter : IMovementDirectionHandler
{
    private KeyCode forwardKey;
    private KeyCode rightKey;
    private KeyCode leftKey;
    Transform transform;

    public PlayerMovementDirectionGetter(Transform transform, KeyCode forwardKey, KeyCode rightKey, KeyCode leftKey)
    {
        this.transform = transform;
        this.forwardKey = forwardKey;
        this.rightKey = rightKey;
        this.leftKey = leftKey;
    }

    public Vector2 GetMovementDirection()
    {
        Vector2 direction = Vector2.zero;

        if (Input.GetKey(forwardKey))
        {
            direction = transform.up;
        }

        return direction;
    }

    public Vector3 GetRotationDirection()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(rightKey))
        {
            direction.z -= 1f;
        }
        if (Input.GetKey(leftKey))
        {
            direction.z += 1f;
        }
        return direction;
    }
}
