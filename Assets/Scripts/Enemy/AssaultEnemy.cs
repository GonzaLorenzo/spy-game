using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultEnemy : Enemy, IShootable
{
    private Animator _myAnimator;
    private float timeToDestroy = 3f;

    private void Start()
    {
        _myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        Patrol();
    }

    public void Shoot()
    {
        _myAnimator.SetTrigger("IsDead");
        canMove = false;
        Destroy(this, timeToDestroy);
        
        //Animator de muerte
        //Dejar de Patrullar y capaz instanciar particulas de sangre
    }
}
