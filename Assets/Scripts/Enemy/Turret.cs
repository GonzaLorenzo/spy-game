using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject _myCannon;
    [SerializeField] private GameObject _player;
    [SerializeField] private ParticleSystem _myBullets;
    [Header("Variables")]
    [SerializeField] private float _distanceToStart;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _timePassed;
    [SerializeField] private float _waitShootingTime;
    [SerializeField] private float _waitStopTime;
    private bool _isShooting;

    void Update()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) < _distanceToStart)
        {
            Vector3 dir = _player.transform.position - _myCannon.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = lookRotation.eulerAngles;

            _myCannon.transform.rotation = Quaternion.Lerp(_myCannon.transform.rotation, Quaternion.Euler(0f, rotation.y, 0f), _rotationSpeed * Time.deltaTime);

            /* if(_timePassed > 0)
            {
                _timePassed -= Time.deltaTime;
            }
            else if(_isShooting)
            {
                StartCoroutine("StopShooting");
            }
            else
            {
                StartCoroutine("StartShooting");
            } */
        }
    }
}
