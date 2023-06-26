using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : Enemy, IObservable
{
    private Animator _myAnimator;
    [SerializeField]
    private CanvasManager canvasManager;

    IObserver _myObserver;
    [SerializeField] private bool _isStopabble = true;
    private void Start()
    {
        canStop = _isStopabble;
        _myAnimator = GetComponent<Animator>();
        Subscribe(canvasManager);
    }

    public override void AnimMove()
    {
        _myAnimator.SetBool("IsMoving", true);
    }

    public override void AnimStay()
    {
        _myAnimator.SetBool("IsMoving", false);
    }

    private void Update()
    {
        Patrol();
    }

    public override void DetectPlayer()
    {
        canMove = false;

        NotifyToObservers("PlayerLost");
    }

    public void SwitchCanMove()
    {
        canMove = !canMove;
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
        if (_myObserver != null)
        {
            _myObserver = null;
        }
    }
}
