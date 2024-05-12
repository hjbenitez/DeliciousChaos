using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public abstract Transform GetNozzle();
    public abstract Projectile GetProjectile();
    public abstract float GetFireRate();

    public abstract void PlaySFX();
}
