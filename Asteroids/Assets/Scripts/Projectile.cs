using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Projectile : MonoBehaviour
{
    private float speed;
    private float lifetime;
    private float birthTime;

    private Movement movement;
    private IMovementDirectionHandler movementDirectionHandler;

    public static event System.Action<Projectile> ProjectileDestroyed;

    public void Init(Gun.ProjectileParams projectileParams, Vector2 initialPosition, Vector3 rotation)
    {
        speed = projectileParams.Speed;
        lifetime = projectileParams.Lifetime;
        birthTime = Time.time;

        movementDirectionHandler = new ProjectileMovementDirectionHandler(transform);
        movement = GetComponent<Movement>();
        movement.Init(speed, initialPosition);

        transform.rotation = Quaternion.identity;
        transform.Rotate(rotation);
    }

    public void Move(float deltaTime)
    {
        movement.Move(movementDirectionHandler.GetMovementDirection(), deltaTime);
    }

    public void CheckLifetime(float currentTime)
    {
        if (currentTime - birthTime > lifetime)
        {
            Destroy();
        }
    }

    private void Destroy()
    {
        ProjectileDestroyed(this);
    }
}
