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
    private bool isShooting = false;

    void Update()
    {
        if(_timePassed > 0)
        {
            _timePassed -= Time.deltaTime;
        }
        else if(isShooting)
        {
            StartCoroutine("StopShooting");
            /* _myBullets.Stop();
            _myLight.color = Color.green;
            _timePassed = _waitStopTime; */
        }
        else //if(_myBullets.isStopped)
        {
            StartCoroutine("StartShooting");
            /* _myBullets.Play();
            _myLight.color = Color.red;
            _timePassed = _waitShootingTime; */
        }
    }

    IEnumerator StartShooting()
    {
        _myLight.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        _myBullets.Play();
        _timePassed = _waitShootingTime;
        isShooting = true;
    }

    IEnumerator StopShooting()
    {
        _myBullets.Stop();
        yield return new WaitForSeconds(1f);
        _myLight.color = Color.green;
        _timePassed = _waitStopTime;
        isShooting = false;
    }
}
