using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour, IObserver
{
    //[SerializeField]
    //private GameObject WinUI;
    //[SerializeField]
    //private GameObject LoseUI;
    [SerializeField]
    private Ads ads;

    [SerializeField]
    private PlayerMovement playerSpeed;

    List<IObserver> _allObservers = new List<IObserver>();

    private void Start()
    {
        AudioManager.instance.Play("GoodLuck");
    }

    void PlayerLost()
    {
        Debug.Log("Perdiste :(");
        playerSpeed.ResetSpeed();
        var screenLose = Instantiate(Resources.Load<ScreenLose>("LoseCanvas"));
        ScreenManager.Instance.Push(screenLose);

        //LoseUI.SetActive(true);
        //Sonido alarma
        //Anim UI

    }

    void PlayerWon()
    {
        AudioManager.instance.Play("GoodJob");
        Debug.Log("Ganaste :D");

        var screenWin = Instantiate(Resources.Load<ScreenWin>("WinCanvas"));
        ScreenManager.Instance.Push(screenWin);
        
        ads.ShowAd();
        //WinUI.SetActive(true);
        //audioManager.GetComponent<AudioManager>().Play("GoodJob");       
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
