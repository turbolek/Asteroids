using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsObjectPool : ObjectPool<Asteroid>
{
    protected override void SubscribeToEvents()
    {
        Asteroid.AsteroidDestroyed += OnAsteroidDestroyed;
    }

    public Asteroid GetAsteroid(Vector2 initialPosition)
    {
        Asteroid asteroid = GetFromPool();

        if (asteroid != null)
        {
            asteroid.Init(initialPosition);
        }

        return asteroid;
    }

    private void OnAsteroidDestroyed(Asteroid asteroid)
    {
        OnObjectDestroyed(asteroid);
    }
}
