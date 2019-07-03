using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    private List<Projectile> activeProjectiles = new List<Projectile>();
    private bool initialized;

    public void Init()
    {
        Gun.ProjectileCreated += OnProjectileCreated;
        Projectile.ProjectileDestroyed += OnProjectileDestroyed;
        initialized = true;
    }

    private void OnProjectileCreated(Projectile projectile)
    {
        activeProjectiles.Add(projectile);
    }

    private void OnProjectileDestroyed(Projectile projectile)
    {
        activeProjectiles.Remove(projectile);
    }

    private void Update()
    {
        if (!initialized)
        {
            return;
        }

        List<Projectile> projectilesToRemove = new List<Projectile>();
        float frameTime = Time.time;
        float deltaTime = Time.deltaTime;

        for (int i = activeProjectiles.Count - 1; i >= 0; i--)
        {
            Projectile projectile = activeProjectiles[i];
            if (projectile != null)
            {
                projectile.Move(deltaTime);
                projectile.CheckLifetime(frameTime);
            }
            else
            {
                projectilesToRemove.Add(projectile);
            }
        }

        RemoveActiveProjectiles(projectilesToRemove);
    }

    private void RemoveActiveProjectiles(List<Projectile> projectilesToRemove)
    {
        for (int i = 0; i < projectilesToRemove.Count; i++)
        {
            activeProjectiles.Remove(projectilesToRemove[i]);
        }
    }
}
