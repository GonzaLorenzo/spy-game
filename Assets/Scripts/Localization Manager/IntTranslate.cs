using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntTranslate : MonoBehaviour
{
    public string ID;

    public LanguageManager manager;

    public Text myView;

    void Awake()
    {
        manager.onUpdate += ChangeLang;
    }

    void ChangeLang()
    {
        var value = int.Parse(manager.GetTranslate(ID));
        myView.text = manager.GetTranslate(ID);
    }
}