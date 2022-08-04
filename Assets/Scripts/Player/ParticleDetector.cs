using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDetector : MonoBehaviour, IObservable
{
    private CanvasManager canvasManager;
    IObserver _myObserver;
    private bool _playerLost;
    private float _myParticleDuration;
    private ParticleSystem _myParticleSystem;

    void Start()
    {
        canvasManager = GameObject.Find("CanvasManager").GetComponent<CanvasManager>();
        Subscribe(canvasManager);
        
        _myParticleSystem = GetComponent<ParticleSystem>();
        _myParticleSystem.Stop();

        var main = _myParticleSystem.main;
        main.duration = _myParticleDuration;

        _myParticleSystem.Play();

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<ParticleSystem>().Stop();
            var psmain = transform.GetChild(i).GetComponent<ParticleSystem>().main;
            psmain.duration = _myParticleDuration;
            transform.GetChild(i).GetComponent<ParticleSystem>().Play();
        }
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

    public ParticleDetector SetDuration(float seconds)
    {
        _myParticleDuration = seconds;
        return this;
    }

    public ParticleDetector SetRotation(Vector3 dir)
    {
        transform.forward = dir;
        return this;
    }
}
