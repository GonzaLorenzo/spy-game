using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultEnemy : Enemy, IShootable
{
    private Animator _myAnimator;
    private float timeToDestroy = 3f;
    private CapsuleCollider _myCollider;

    private void Start()
    {
        _myAnimator = GetComponent<Animator>();
        _myCollider = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        Patrol();
    }

    public void Shoot()
    {
        _myAnimator.SetTrigger("IsDead");
        canMove = false;
        _myCollider.enabled = !_myCollider.enabled;

        //Destroy(this, timeToDestroy); Mejor que se queden

        //En su momento también deshabilitar el campo de visión.
        
        //Animator de muerte
        //Dejar de Patrullar y capaz instanciar particulas de sangre
    }
}
