using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour, IObservable
{
    [SerializeField]
    private CanvasManager canvasManager;

    IObserver _myObserver;

    private void Awake()
    {
        Subscribe(canvasManager);
    }

    private void OnTriggerEnter(Collider other)
    {
        NotifyToObservers("PlayerWon");
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
        if (_myObserver != null)
        {
            _myObserver = null;
        }
    }
}
