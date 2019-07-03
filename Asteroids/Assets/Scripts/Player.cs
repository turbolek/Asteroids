using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Rotation))]
public class Player : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 5f;
    [SerializeField]
    private float rotationSpeed = 90f;
    [SerializeField]
    private KeyCode forwardKey = KeyCode.W,
                    rightKey = KeyCode.D,
                    leftKey = KeyCode.A;

    private bool initialized = false;

    private Gun gun;
    private Movement movement;
    private Rotation rotation;
    private IMovementDirectionHandler movementDirectionHandler;
    private Transform cachedTransform;

    public void Init(ProjectileObjectPool projectilePool)
    {
        movementDirectionHandler = new PlayerMovementDirectionGetter(transform, forwardKey, rightKey, leftKey);
        movement = GetComponent<Movement>();
        cachedTransform = transform;
        movement.Init(movementSpeed, cachedTransform.position);

        rotation = GetComponent<Rotation>();
        rotation.Speed = rotationSpeed;

        gun = GetComponentInChildren<Gun>();
        gun.Init(projectilePool);

        initialized = true;
    }

    private void Update()
    {
        if (!initialized)
        {
            return;
        }
        movement.Move(movementDirectionHandler.GetMovementDirection(), Time.deltaTime);
        rotation.Rotate(movementDirectionHandler.GetRotationDirection());
        if (gun != null)
        {
            gun.HandleShooting();
        }
    }
}
