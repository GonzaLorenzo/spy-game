using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : Enemy
{
    private Animator _myAnimator;

    public override void AnimMove()
    {
        throw new System.NotImplementedException();
    }

    public override void AnimStay()
    {
        throw new System.NotImplementedException();
    }

    private void Start()
    {
        _myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        Patrol();
    }
}
