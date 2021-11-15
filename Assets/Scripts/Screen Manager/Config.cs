using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public Transform mainGame;
    public Transform overlayGame;

    void Start()
    {
        ScreenManager.Instance.Push(new ScreenGO(mainGame));
    }

    void Update()
    {
        
    }
}


