using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasTank : MonoBehaviour, IShootable
{
    [SerializeField] private MechBoss _mech;
    [SerializeField] private ParticleSystem _fireParticles;
    [SerializeField] private BoxCollider _mechTrigger;

    public void Shoot()
    {
        _fireParticles.Play();
        _mechTrigger.enabled = true;
    }
}
