using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticGun : Gun
{
    [SerializeField]
    private float shootingTimeInterval = 0.5f;
    private float lastShotTime;

    protected override bool CanShoot()
    {
        return Time.time - lastShotTime >= shootingTimeInterval;
    }

    protected override void Shoot()
    {
        base.Shoot();
        lastShotTime = Time.time;
    }
}
