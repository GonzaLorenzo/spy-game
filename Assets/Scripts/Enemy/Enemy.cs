using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public List<Transform> waypoints;
    public float speed;
    private int _currentWaypoint = 0;
    private bool canMove = true;

    public void Patrol()
    {
        if (canMove)
        {
            Vector3 dir = waypoints[_currentWaypoint].position - transform.position;
            transform.forward = dir;
            transform.position += transform.forward * speed * Time.deltaTime;

            if (dir.magnitude < 0.1f)
            {
                AwaitInPlace(2f);
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
        canMove = false;
        //SoldadoState = 1f;
        //SetSoldadoState();
        yield return new WaitForSeconds(time);
        canMove = true;
        //SoldadoState = 2f;
        //SetSoldadoState();

    }
}
