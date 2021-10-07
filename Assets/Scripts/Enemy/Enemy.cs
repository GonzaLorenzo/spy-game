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
                    AwaitInPlace(2f);
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
    }

    private void AwaitInPlace(float time)
    {
        StartCoroutine(LockMovementFor(time));
    }
    private IEnumerator LockMovementFor(float time)
    {
        canResume = false;
        //SoldadoState = 1f;
        //SetSoldadoState();
        yield return new WaitForSeconds(time);
        canResume = true;
        AnimMove();
        //_myAnimator.SetBool("IsMoving", true);
        //SoldadoState = 2f;
        //SetSoldadoState();
    }

    public abstract void AnimMove();
    public abstract void AnimStay();
    public abstract void DetectPlayer();
}
