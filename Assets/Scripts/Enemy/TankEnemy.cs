using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : Enemy
{
    private Animator _myAnimator;

    private void Start()
    {
        _myAnimator = GetComponent<Animator>();
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
        
    }
}
