using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineFork : Weapon
{
    public Transform nozzle;
    public Projectile projectile;
    public float fireRate;

    public AudioSource source;
    float sfxMaxVolume = 0.5f;

    public void Start()
    {
        source.volume = sfxMaxVolume * GameManager.sfxVolume * GameManager.mainVolume;
    }

    public override Transform GetNozzle()
    {
        return nozzle;
    }

    public override Projectile GetProjectile()
    {
        return projectile;
    }

    public override float GetFireRate()
    {
        return fireRate;
    }

    public override void PlaySFX()
    {
        source.Play();
    }
}
