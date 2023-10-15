using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasTank : MonoBehaviour, IShootable
{
    [SerializeField] private MechBoss _mech;
    [SerializeField] private float explosionRadius;
    [SerializeField] private LayerMask explosionLayer;
    [SerializeField] private ParticleSystem _fireParticles;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Shoot()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius, explosionLayer);
        foreach(var collider in hitColliders)
        {
            _mech.TakeDamage();
        }
        _fireParticles.Play();
    }
}
