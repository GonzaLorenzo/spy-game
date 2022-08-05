using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour, IObservable
{
    private CanvasManager canvasManager;
    IObserver _myObserver;
    private bool _playerLost;
    private float _myParticleDuration;
    private float _myParticleLifeTime;
    private ParticleSystem _myParticleSystem;

    void Start()
    {
        canvasManager = GameObject.Find("CanvasManager").GetComponent<CanvasManager>();
        Subscribe(canvasManager);
    }

    void OnParticleCollision(GameObject other)
    {
        if(other.GetComponent<PlayerMovement>() && !_playerLost)
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


