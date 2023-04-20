using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultEnemy : Enemy, IShootable, IObservable
{
    [SerializeField] private ParticleSystem _bloodParticle;
    private Animator _myAnimator;
    private float timeToDestroy = 3f;
    private CapsuleCollider _myCollider;
    [SerializeField]
    private GameObject _enemyLight;
    [SerializeField]
    private GameObject _playerDetector;
    [SerializeField]
    private CanvasManager canvasManager;


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
        Destroy(_enemyLight);
        _playerDetector.GetComponent<EnemyLight>().EnemyIsDead();
        _bloodParticle.Play();
        //Destroy(this, timeToDestroy); || Mejor que se queden

        //Animator de muerte
        //Dejar de Patrullar y capaz instanciar particulas de sangre
    }

    public override void DetectPlayer()
    {
        canMove = false;
        Debug.Log("Llegué a Assault");

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
