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
    [SerializeField]
    private float asteroidRespawnTime;

    private Asteroid[] asteroids;
    private bool initialized = false;
    private List<float> respawnTimes;
    private AsteroidsSpawner asteroidsSpawner;

    public void Init()
    {
        Asteroid.AsteroidDestroyed += OnAsteroidDestroyed;

        AsteroidsObjectPool asteroidsObjectPool = new AsteroidsObjectPool();
        asteroidsSpawner = new AsteroidsSpawner(asteroidsObjectPool, asteroidGridSizeX, asteroidGridSizeY, asteroidGridTileSize);
        respawnTimes = new List<float>();

        int asteroidsNumber = asteroidGridSizeX * asteroidGridSizeY;
        asteroidsObjectPool.Init(asteroidPrefab, asteroidsNumber, asteroidsNumber, null);
        asteroids = asteroidsSpawner.SpawnAllAsteroids();
        StartCoroutine(AsteroidRespawnCoroutine());

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

    private void OnAsteroidDestroyed(Asteroid asteroid)
    {
        respawnTimes.Add(Time.time + asteroidRespawnTime);
    }

    private IEnumerator AsteroidRespawnCoroutine()
    {
        while (true)
        {
            while (respawnTimes.Count > 0 && respawnTimes[0] <= Time.time)
            {
                asteroidsSpawner.SpawnAsteroidAtRandomPosition();
                respawnTimes.RemoveAt(0);
            }
            yield return null;
        }
    }
}
