using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    //[SerializeField] private ParticleDetector _fireParticles;
    [SerializeField] private GameObject _electricArc;
    private bool _isOn = false;
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
            if(!_isOn)
            {
                _electricArc.SetActive(true);
                _isOn = true;
            }
            else
            {
                _isOn = false;
                _electricArc.SetActive(false);
            }
            
            
            _timePassed = _shootTime;
        }

    }
}
