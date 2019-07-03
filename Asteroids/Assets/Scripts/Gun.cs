using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    [System.Serializable]
    public class ProjectileParams
    {
        [SerializeField]
        private float speed;
        public float Speed { get { return speed; } }

        [SerializeField]
        private float lifetime;
        public float Lifetime { get { return lifetime; } }
    }

    [SerializeField]
    private ProjectileParams projectileParams;
    private ProjectileObjectPool projectilePool;

    public static event System.Action<Projectile> ProjectileCreated;
    private Transform cachedTransform;

    public void Init(ProjectileObjectPool projectilePool)
    {
        this.projectilePool = projectilePool;
        cachedTransform = transform;
    }

    public void HandleShooting()
    {
        if (CanShoot())
        {
            Shoot();
        }
    }

    protected abstract bool CanShoot();

    protected virtual void Shoot()
    {
        Projectile projectile = projectilePool.GetProjectile(projectileParams, cachedTransform.position, cachedTransform.rotation.eulerAngles);
        if (projectile != null)
        {
            ProjectileCreated(projectile);
        }
    }
}
