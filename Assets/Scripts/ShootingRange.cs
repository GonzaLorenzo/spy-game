using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRange : MonoBehaviour
{
    [SerializeField] private Light _myLight;
    [SerializeField] private ParticleSystem _myBullets;
    [SerializeField] private float _timePassed;
    [SerializeField] private float _waitShootingTime;
    [SerializeField] private float _waitStopTime;

    void Update()
    {
        if(_timePassed > 0)
        {
            _timePassed -= Time.deltaTime;
        }
        else if(!_myBullets.isStopped)
        {
            _myBullets.Stop();
            _myLight.color = Color.green;
            _timePassed = _waitStopTime;
        }
        else //if(_myBullets.isStopped)
        {
            _myBullets.Play();
            _myLight.color = Color.red;
            _timePassed = _waitShootingTime;
        }
    }
}
