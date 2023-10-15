using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour, IObservable
{
    [SerializeField] private Rigidbody _rb;
    private MissileTarget myTarget;
    [SerializeField] private float _speed;
    private Vector3 dir;
    [SerializeField] private float explosionRadius;
    [SerializeField] private LayerMask explosionLayer;
    IObserver _myObserver;
    private CanvasManager canvasManager;

    void Start()
    {
        canvasManager = GameObject.FindGameObjectWithTag("CanvasManager").GetComponent<CanvasManager>();
        Subscribe(canvasManager);

        dir = myTarget.transform.position - transform.position;
        transform.forward = dir;
    }

    void Update()
    {
        transform.position = new Vector3(myTarget.transform.position.x, transform.position.y, myTarget.transform.position.z);
    }

    void OnCollisionEnter(Collision other)
    {
        Explode();
    }

    public Missile SetTarget(MissileTarget target)
    {
        myTarget = target;
        return null;
    }

    public void Explode()
    {
        myTarget.Deactivate();
        
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius, explosionLayer);
        foreach(var collider in hitColliders)
        {
            NotifyToObservers("PlayerLost");
        }

        Destroy(this.gameObject);
        //particulas
        //screen shake
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
