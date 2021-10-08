using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    public delegate void EventReceiver(params object[] parameterContainer);

    static Dictionary<EventsType, EventReceiver> _events;

    public static void SubscribeToEvent(EventsType eventType, EventReceiver listener)
    {
        if(_events == null)
        {
            _events = new Dictionary<EventsType, EventReceiver>();
        }

        if(!_events.ContainsKey(eventType))
        {
            _events.Add(eventType, null);
        }

        _events[eventType] += listener;
    }

    public static void Unsubscribe(EventsType eventType, EventReceiver listener)
    {
        if(_events != null)
        {
            if(_events.ContainsKey(eventType))
            {
                _events[eventType] -= listener;
            }
        }
    }
     
    public static void ExecuteEvent(EventsType eventType, params object[] parameters)
    {
        if(_events == null)
        {
            Debug.Log("No tenemos eventos :(");
            return;
        }

        if(_events.ContainsKey(eventType))
        {
            if(_events[eventType] != null)
            {
                _events[eventType](parameters);
            }
        }
    }

    public static void ExecuteEvent(EventsType eventType)
    {
        ExecuteEvent(eventType, null);
    }

    public enum EventsType
    {
        Event_PlayerWon,
        Event_PlayerLost
    }
}
