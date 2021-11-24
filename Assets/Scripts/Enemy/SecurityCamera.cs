using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour,IObservable
{
    [SerializeField]
    private CanvasManager canvasManager;

    [SerializeField]
    private GameObject _securityCameraLight;
    IObserver _myObserver;

    void Start()
    {
        Subscribe(canvasManager);
    }
    private void Update()
    {
        Vector3 dir = _securityCameraLight.transform.position - transform.position;
        transform.forward = dir;
    }

    public void DetectPlayer()
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
