using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsManager : MonoBehaviour
{
    [Header("Asteroids Settings")]
    [SerializeField]
    private GameObject asteroidPrefab;
    [SerializeField]
    private int asteroidGridSizeX;
    [SerializeField]
    private int asteroidGridSizeY;
    [SerializeField]
    private float asteroidGridTileSize;

    private Asteroid[] asteroids;
    private bool initialized = false;

    public void Init()
    {
        AsteroidsObjectPool asteroidsObjectPool = new AsteroidsObjectPool();
        int asteroidsNumber = asteroidGridSizeX * asteroidGridSizeY;
        asteroidsObjectPool.Init(asteroidPrefab, asteroidsNumber, asteroidsNumber, null);
        AsteroidsSpawner asteroidsSpawner = new AsteroidsSpawner(asteroidsObjectPool, asteroidGridSizeX, asteroidGridSizeY, asteroidGridTileSize);
        asteroids = asteroidsSpawner.SpawnAllAsteroids();
        initialized = true;
    }

    private void Update()
    {
        if (!initialized)
        {
            return;
        }

        float deltaTime = Time.deltaTime;
        Asteroid currentAsteroid;
        for (int i = 0; i < asteroids.Length; i++)
        {
            currentAsteroid = asteroids[i];
            currentAsteroid.Move(deltaTime);
        }
    }

}
