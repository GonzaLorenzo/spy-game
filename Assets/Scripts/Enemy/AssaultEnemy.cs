using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultEnemy : Enemy, IShootable, IObservable
{
    [SerializeField] private ParticleSystem _bloodParticle;
    private Animator _myAnimator;
    private float timeToDestroy = 3f;
    private CapsuleCollider _myCollider;
    [SerializeField] private VisionCone _enemyVisionCone;
    [SerializeField] private CanvasManager canvasManager;
    IObserver _myObserver;

    private void Start()
    {
        _myAnimator = GetComponent<Animator>();
        _myCollider = GetComponent<CapsuleCollider>();
        Subscribe(canvasManager);
    }

    private void Update()
    {
        Patrol();
    }

    public override void AnimMove()
    {
        _myAnimator.SetBool("IsMoving", true);
    }

    public override void AnimStay()
    {
        _myAnimator.SetBool("IsMoving", false);
    }

    public void Shoot()
    {
        _myAnimator.SetTrigger("IsDead");
        canMove = false;
        _myCollider.enabled = !_myCollider.enabled;
        //Destroy(_enemyLight);
        
        _enemyVisionCone.EnemyIsDead();
        _bloodParticle.Play();
        //Destroy(this, timeToDestroy); || Mejor que se queden
    }

    public override void DetectPlayer()
    {
        canMove = false;

        NotifyToObservers("PlayerLost");
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
        if (_myObserver !=  null)
        {
            _myObserver = null;
        }
    }
}
