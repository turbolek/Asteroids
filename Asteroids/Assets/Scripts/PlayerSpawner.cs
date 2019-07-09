using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner
{
    private GameObject playerPrefab;
    private Vector3 spawnPosition;
    private ProjectileObjectPool projectilePool;

    public PlayerSpawner(GameObject playerPrefab, Vector3 spawnPosition, ProjectileObjectPool projectilePool)
    {
        this.playerPrefab = playerPrefab;
        this.spawnPosition = spawnPosition;
        this.projectilePool = projectilePool;
    }

    public Player SpawnPlayer()
    {
        GameObject playerGameObject = GameObject.Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
        Player player = playerGameObject.GetComponent<Player>();

        if (player != null)
        {
            player.Init(projectilePool);
        }
        else
        {
            Debug.LogError("Player prefab has to have Player component");
        }

        return player;
    }

}
