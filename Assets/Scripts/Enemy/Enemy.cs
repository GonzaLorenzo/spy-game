using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public List<Transform> waypoints;
    public float speed;
    private int _currentWaypoint = 0;
    protected bool canMove = true;
    //private Animator _myAnimator;

    public void Patrol()
    {
        if (canMove)
        {
            //_myAnimator.SetBool("IsMoving", true);
            Vector3 dir = waypoints[_currentWaypoint].position - transform.position;
            transform.forward = dir;
            transform.position += transform.forward * speed * Time.deltaTime;

            if (dir.magnitude < 0.1f)
            {
                //_myAnimator.SetBool("IsMoving", false);
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
        //_myAnimator.SetBool("IsMoving", true);
        //SoldadoState = 2f;
        //SetSoldadoState();
    }
}
