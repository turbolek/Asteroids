using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileObjectPool : ObjectPool<Projectile>
{
    protected override void SubscribeToEvents()
    {

        Projectile.ProjectileDestroyed += OnProjectileDestroyed;
    }

    public Projectile GetProjectile(Gun.ProjectileParams projectileParams, Vector2 initialPosition, Vector3 rotation)
    {
        Projectile projectile = GetFromPool();

        if (projectile != null)
        {
            projectile.Init(projectileParams, initialPosition, rotation);
        }

        return projectile;
    }

    private void OnProjectileDestroyed(Projectile projectile)
    {
        OnObjectDestroyed(projectile);
    }
}
