using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public List<Transform> waypoints;
    public float speed;
    private int _currentWaypoint = 0;

    public void Patrol()
    {
        Vector3 dir = waypoints[_currentWaypoint].position - transform.position;
        transform.forward = dir;
        transform.position += transform.forward * speed * Time.deltaTime;

        if (dir.magnitude < 0.1f)
        {
            _currentWaypoint++;
            if (_currentWaypoint > waypoints.Count - 1)
                _currentWaypoint = 0;
        }
    }
     
}
