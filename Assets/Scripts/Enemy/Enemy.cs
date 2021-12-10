using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public List<Transform> waypoints;
    public float speed;
    private int _currentWaypoint = 0;
    protected bool canMove = true;
    private bool canResume = true;
    protected float stopTime = 2f;
    //private Animator _myAnimator;

    public void Patrol()
    {
        if (canMove)
        {
            if (canResume && waypoints.Count > 0)
            {
                AnimMove();
                //_myAnimator.SetBool("IsMoving", true);
                Vector3 dir = waypoints[_currentWaypoint].position - transform.position;
                transform.forward = dir;
                transform.position += transform.forward * speed * Time.deltaTime;

                if (dir.magnitude < 0.1f)
                {
                    AnimStay();
                    //_myAnimator.SetBool("IsMoving", false);
                    AwaitInPlace(stopTime);
                    _currentWaypoint++;
                    if (_currentWaypoint > waypoints.Count - 1)
                        _currentWaypoint = 0;
                }
            }
            else
            {
                AnimStay();
            }
        }
        else
        {
            AnimStay();
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
        AnimMove();
        //_myAnimator.SetBool("IsMoving", true);
    }

    public void GetDistracted(Transform dis)
    {
        waypoints.Add(dis);
        _currentWaypoint = waypoints.Count -1;
    }

    public void ForgetDistraction()
    {
        waypoints.RemoveAt(waypoints.Count - 1);
    }

    public abstract void AnimMove();
    public abstract void AnimStay();
    public abstract void DetectPlayer();

    public Enemy SetPos (Vector3 newPos)
    {
        transform.position = newPos;
        return this;
    }

    public Enemy SetWaypoints (List<Transform> newWaypoints)
    {
        waypoints = newWaypoints;
        return this;
    }

    public Enemy SetRotation(Vector3 newRotation)
    {
        transform.rotation *= Quaternion.Euler(newRotation);
        return this;
    }

}
