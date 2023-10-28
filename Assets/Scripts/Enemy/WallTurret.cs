using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTurret : MonoBehaviour, IObservable
{
    IObserver _myObserver;
    private int _currentWaypoint = 0;
    [SerializeField] private CanvasManager canvasManager;
    [SerializeField] private LineRenderer _laserRenderer;
    [SerializeField] private GameObject _shootPoint;
    [SerializeField] private ParticleSystem _mySparks;
    ParticleSystem.ShapeModule _sparksShape;
    [SerializeField] private List<Transform> waypoints;

    [Header("Variables")]
    [SerializeField] private float speed;
    [SerializeField] private float _laserOffset;
    [SerializeField] private LayerMask _laserLayers;
    [SerializeField] private AudioSource _as;
    

    void Start()
    {
        Subscribe(canvasManager);
        _sparksShape = _mySparks.shape;
        
        _as.Play();
    }

    void Update()
    {
        Patrol();

        RaycastHit hit;
        _laserRenderer.SetPosition(0, _shootPoint.transform.position);
        if (Physics.Raycast(_shootPoint.transform.position, transform.forward, out hit, 30, _laserLayers))
        {
            _laserRenderer.SetPosition(1, hit.point);
            float Aux = _shootPoint.transform.position.x - _laserOffset;
            Vector3 positionDifference = new Vector3(_sparksShape.position.x, _sparksShape.position.y, Aux - hit.point.x);
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
    }

    public void Patrol()
    {
        if (waypoints.Count > 0)
        {
            Vector3 dir = waypoints[_currentWaypoint].position - transform.position;
            //transform.right = dir;
            //transform.position += transform.right * speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, waypoints[_currentWaypoint].position, speed * Time.deltaTime);

            if (dir.magnitude < 0.1f)
            {
                _currentWaypoint++;
                if (_currentWaypoint > waypoints.Count - 1)
                _currentWaypoint = 0;
            }
        }
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
}
