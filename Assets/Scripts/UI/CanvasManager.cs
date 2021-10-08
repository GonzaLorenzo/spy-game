using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour, IObserver
{
    [SerializeField]
    private GameObject WinUI;
    [SerializeField]
    private GameObject LoseUI;

    List<IObserver> _allObservers = new List<IObserver>();

    private void Start()
    {
        //EventManager.SubscribeToEvent(EventManager.EventsType.Event_PlayerLost, PlayerLost);
    }

    void PlayerLost()
    {
        Debug.Log("Perdiste :(");
        LoseUI.SetActive(true);
        //Sonido alarma
        //Anim UI
    }

    void PlayerWon()
    {
        Debug.Log("Ganaste :D");
        WinUI.SetActive(true);
        //Voz GoodJob
        //Anim UI
    }

    public void Notify(string action)
    {
        if(action == "PlayerLost")
        {
            PlayerLost();
        }
        else if (action == "PlayerWon")
        {
            PlayerWon();
        }

    }
}
