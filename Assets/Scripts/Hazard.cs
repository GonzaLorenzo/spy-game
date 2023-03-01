using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour, IObservable
{
    [SerializeField] private CanvasManager canvasManager;
    IObserver _myObserver;

    void Start()
    {
        Subscribe(canvasManager);
    }

    void OnTriggerEnter(Collider other)
    {
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


