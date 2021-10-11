using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour, IObserver
{
    public GameObject audioManager;
    [SerializeField]
    private GameObject WinUI;
    [SerializeField]
    private GameObject LoseUI;

    List<IObserver> _allObservers = new List<IObserver>();

    private void Start()
    {
        audioManager.GetComponent<AudioManager>().Play("GoodLuck");
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
        audioManager.GetComponent<AudioManager>().Play("GoodJob");
        WinUI.SetActive(true);
        
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
