using System.Net.Sockets;
using System.Linq.Expressions;
using System.Dynamic;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Turret : MonoBehaviour, IObservable
{
    [SerializeField] private CanvasManager canvasManager;
    IObserver _myObserver;
    [SerializeField] private GameObject _laser;
    [SerializeField] private LineRenderer _laserRenderer;
    [SerializeField] private GameObject _myCannon;
    [SerializeField] private GameObject _shootPoint;
    [SerializeField] private GameObject _player;
    [SerializeField] private ParticleSystem _mySparks;
    ParticleSystem.ShapeModule _sparksShape;
    [Header("Variables")]
    [SerializeField] private float _laserOffset;
    [SerializeField] private LayerMask _laserLayers;
    [SerializeField] private LayerMask _laserWallLayers;
    [SerializeField] private float _distanceToStart;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _timePassed;
    [SerializeField] private float _waitShootingTime;
    [SerializeField] private float _waitStopTime;
    [SerializeField] private bool _isShooting;
    private bool firstLoop = false;

    void Start()
    {
        Subscribe(canvasManager);
        _sparksShape = _mySparks.shape;
        _timePassed = _waitShootingTime;
    }

    void Update()
    {
        Vector3 dir = _player.transform.position - _shootPoint.transform.position;
        if (Vector3.Distance(transform.position, _player.transform.position) < _distanceToStart && !Physics.Raycast(_shootPoint.transform.position, dir, dir.magnitude, _laserWallLayers))
        {
            if(!_isShooting) //&& !Physics.Raycast(_shootPoint.transform.position, transform.forward, dir.magnitude, _laserWallLayers))
            {
                StartShooting();
            }
            else
            {
                StopShooting();
            }
        }
        else
        {
           NoPlayerInSight();
        }
    }

    private void StartShooting()
    {
        if(!firstLoop)
        {
            _laser.SetActive(true);
            _mySparks.Play();
            firstLoop = true;
        }

        Vector3 dir = _player.transform.position - transform.position;
        Vector3 shootDir = _player.transform.position - _shootPoint.transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, rotation.y, 0f), _rotationSpeed * Time.deltaTime);

        RaycastHit hit;
        _laserRenderer.SetPosition(0, _shootPoint.transform.position);
        if (Physics.Raycast(_shootPoint.transform.position, transform.forward, out hit, 30, _laserLayers))
        {
            _laserRenderer.SetPosition(1, hit.point);
            float Aux = _shootPoint.transform.position.z - _laserOffset;
            Vector3 positionDifference = new Vector3(_sparksShape.position.x, _sparksShape.position.y, Aux - hit.point.z);
            _sparksShape.position = positionDifference;
            if (hit.collider.GetComponent<PlayerMovement>())
            {
                _myObserver.Notify("PlayerLost");
            }
        }
        else
        {
            Debug.Log("error");
        }

        if(_timePassed > 0)
        {
            _timePassed -= Time.deltaTime;
        }
        else
        {
            _isShooting = true;
            firstLoop = false;
            _timePassed = _waitStopTime;
        }
    }

    private void StopShooting()
    {
        if(!firstLoop)
        {
            _laser.SetActive(false);
            _mySparks.Stop();
            firstLoop = true;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-30f, 180f, 0f), _rotationSpeed * Time.deltaTime);

        if(_timePassed > 0)
        {
            _timePassed -= Time.deltaTime;
        }
        else
        {
            _isShooting = false;
            firstLoop = false;
            _timePassed = _waitShootingTime;
        }
    }

    private void NoPlayerInSight()
    {
        _laser.SetActive(false);
        _mySparks.Stop();
        _isShooting = true; 
        _timePassed = .1f;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-30f, 180f, 0f), _rotationSpeed * Time.deltaTime);
    }

    public void NotifyToObservers(string action)
    {
        _myObserver.Notify(action);
    }

    public void Subscribe(IObserver obs)
    {
        if (_myObserver == null)
        {
            _myObserver = obs;
        }
    }

    public void Unsubscribe(IObserver obs)
    {
        if (_myObserver !=  null)
        {
            _myObserver = null;
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _distanceToStart);
    }
}
