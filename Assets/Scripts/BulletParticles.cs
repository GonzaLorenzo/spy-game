using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticles : MonoBehaviour, IObservable
{
    [SerializeField] private CanvasManager canvasManager;
    IObserver _myObserver;

    void Start()
    {
        Subscribe(canvasManager);
    }

    void OnParticleCollision(GameObject other)
    {
        var player = other.gameObject.GetComponent<PlayerMovement>();

        if (player != null)
        {
            _myObserver.Notify("PlayerLost");
            Destroy(this.gameObject);
        }
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
