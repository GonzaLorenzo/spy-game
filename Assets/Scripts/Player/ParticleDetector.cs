using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDetector : MonoBehaviour, IObservable
{
    [SerializeField]
    private CanvasManager canvasManager;
    IObserver _myObserver;
    private bool _playerLost;

    void Start()
    {
        Subscribe(canvasManager);
    }

    void OnParticleCollision(GameObject other)
    {
        if(!_playerLost)
        {
            NotifyToObservers("PlayerLost");
            _playerLost = true;
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
