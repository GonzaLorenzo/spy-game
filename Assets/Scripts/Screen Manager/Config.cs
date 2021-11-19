using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public Transform mainGame;

    void Start()
    {
        ScreenManager.Instance.Push(new ScreenGO(mainGame));
    }

    //void Update()
    //{      
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
            //var screenWin = Instantiate(Resources.Load<ScreenWin>("WinCanvas"));
            //ScreenManager.Instance.Push(screenWin);
        //}
    //}
}


