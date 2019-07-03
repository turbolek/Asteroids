using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [Header("Player Spawner Settings")]
    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    private Vector3 playerSpawnPosition;

    [Header("Projectile Settings")]
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private ProjectileManager projectileManager;
    [SerializeField]
    private int projectilePoolInitialSize;
    [SerializeField]
    private int projectilePoolMaxSize;

    [Header("Asteroid Settings")]
    [SerializeField] AsteroidsManager asteroidManager;

    private PlayerSpawner playerSpawner;

    List<string> list = new List<string>();

    private void Awake()
    {
        ProjectileObjectPool projectileObjectPool = new ProjectileObjectPool();
        projectileObjectPool.Init
            (
            projectilePrefab,
            projectilePoolMaxSize,
            projectilePoolInitialSize,
            projectileManager.transform
            );
        projectileManager.Init();
        asteroidManager.Init();

        playerSpawner = new PlayerSpawner(playerPrefab, playerSpawnPosition, projectileObjectPool);
        playerSpawner.SpawnPlayer();
    }
}
