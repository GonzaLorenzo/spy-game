using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour, IObserver
{
    //[SerializeField]
    //private GameObject WinUI;
    //[SerializeField]
    //private GameObject LoseUI;
    [SerializeField] private Ads ads;
    public int _generatedCode { get; private set; }
    [SerializeField] private ElectricDoor _electricDoor;
    public ElectricDoor ElectricDoor { get { return _electricDoor; } }
    [SerializeField] private PlayerMovement playerSpeed;
    List<IObserver> _allObservers = new List<IObserver>();

    private void Start()
    {
        //AudioManager.instance.Play("GoodLuck");
        GenerateKeypadCode();
    }

    void PlayerLost()
    {
        Debug.Log("Perdiste :(");
        //playerSpeed.ResetSpeed(); No more Ads. Hasta dar el otro final.
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
        
        //ads.ShowAd(); No more ads. Hasta que presente el final de MotoresII

        //WinUI.SetActive(true);
        //audioManager.GetComponent<AudioManager>().Play("GoodJob");       
        //Anim UI
    }

    private void GenerateKeypadCode()
    {
        _generatedCode = Random.Range(100,1000);
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
