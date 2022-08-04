using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [SerializeField] private ParticleDetector _fireParticles;
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private float _timePassed;
    [SerializeField] private float _shootTime;
    [SerializeField] private float _particleDuration;
    [SerializeField] private float _particleLifeTime;

    
    void Update()
    {
        if(_timePassed > 0)
        {
            _timePassed -= Time.deltaTime;
        }
        else
        {
            Instantiate(_fireParticles, _shotPoint.position, Quaternion.identity)
            .SetDuration(_particleDuration)
            .SetLifeTime(_particleLifeTime)
            .SetRotation(transform.forward);

            
            _timePassed = _shootTime;
        }

    }
}
