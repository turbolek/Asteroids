using UnityEngine;
using System.Collections.Generic;

public class AsteroidsSpawner
{
    private float tileSize;
    private int gridSizeX;
    private int gridSizeY;
    private Vector2[] tileCenterPositions;
    private AsteroidsObjectPool asteroidsPool;

    public AsteroidsSpawner(AsteroidsObjectPool asteroidsPool, int gridSizeX, int gridSizeY, float tileSize)
    {
        this.asteroidsPool = asteroidsPool;
        this.gridSizeX = gridSizeX;
        this.gridSizeY = gridSizeY;
        this.tileSize = tileSize;

        SetTileCenterPositions();
    }

    private void SetTileCenterPositions()
    {
        int numberOfTiles = gridSizeX * gridSizeY;
        tileCenterPositions = new Vector2[numberOfTiles];

        float gridWidth = gridSizeX * tileSize;
        float gridHeight = gridSizeY * tileSize;
        Vector2 gridCenterShift = new Vector2(-gridWidth / 2f, -gridHeight / 2f);

        float tileBottomLeftX;
        float tileBottomLeftY;
        Vector2 tileCenter = Vector2.zero;
        for (int i = 0; i < gridSizeX; i++)
        {
            tileBottomLeftX = i * tileSize;
            for (int j = 0; j < gridSizeY; j++)
            {
                tileBottomLeftY = j * tileSize;
                tileCenter.x = tileBottomLeftX - (float)tileSize / 2f;
                tileCenter.y = tileBottomLeftY - (float)tileSize / 2f;
                tileCenter += gridCenterShift;

                tileCenterPositions[i * gridSizeX + j] = tileCenter;
            }
        }
    }

    public Asteroid[] SpawnAllAsteroids()
    {
        Asteroid[] asteroids = new Asteroid[tileCenterPositions.Length];
        for (int i = 0; i < tileCenterPositions.Length; i++)
        {
            Vector2 tileCenterPosition = tileCenterPositions[i];
            Asteroid asteroid = asteroidsPool.GetAsteroid(tileCenterPosition);
            if (asteroid != null)
            {
                asteroids[i] = asteroid;
            }
        }
        return asteroids;
    }
}
