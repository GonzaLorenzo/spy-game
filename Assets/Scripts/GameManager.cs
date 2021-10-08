using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject WinUI;
    [SerializeField]
    private GameObject LoseUI;

    private void Start()
    {
        Instantiate(LoseUI);
        //EventManager.SubscribeToEvent(EventManager.EventsType.Event_PlayerLost, PlayerLost);
    }

    void PlayerLost(params object[] parameterContainer)
    {
        Debug.Log("Perdiste :(");
    }
}
