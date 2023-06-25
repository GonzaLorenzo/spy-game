using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovementScript : MonoBehaviour
{
    public List<Transform> waypoints;
    private int _currentWaypoint = 0;
    private bool canResume = true;
    private float stopTime = 2f;
    [SerializeField] private float speed;


    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (canResume && waypoints.Count > 0)
        {
            Vector3 dir = waypoints[_currentWaypoint].position - transform.position;
            transform.forward = dir;
            transform.position += transform.forward * speed * Time.deltaTime;

            if (dir.magnitude < 0.1f)
            {
            AwaitInPlace(stopTime);
            _currentWaypoint++;
            if (_currentWaypoint > waypoints.Count - 1)
            _currentWaypoint = 0;
            }
        }
    }

    private void AwaitInPlace(float time)
    {
        StartCoroutine(LockMovementFor(time));
    }

    private IEnumerator LockMovementFor(float time)
    {
        canResume = false;
        yield return new WaitForSeconds(time);
        canResume = true;
    }
}
