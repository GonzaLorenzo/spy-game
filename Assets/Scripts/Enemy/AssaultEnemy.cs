using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultEnemy : Enemy
{
    private Animator _myAnimator;

    private void Start()
    {
        _myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        Patrol();
    }

}
