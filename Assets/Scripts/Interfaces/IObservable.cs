using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObservable
{
    void NotifyToObservers(string action);
    void Subscribe(IObserver obs);
    void Unsubscribe(IObserver obs); 
}
