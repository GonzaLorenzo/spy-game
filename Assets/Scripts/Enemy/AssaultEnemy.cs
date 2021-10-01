using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultEnemy : Enemy, IShootable
{
    private Animator _myAnimator;

    public void Shoot()
    {
        //Animator de muerte
        //Dejar de Patrullar y capaz instanciar particulas de sangre
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
