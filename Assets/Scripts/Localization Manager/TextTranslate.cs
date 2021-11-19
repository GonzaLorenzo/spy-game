using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextTranslate : MonoBehaviour
{
    public string ID;

    public LanguageManager manager;

    public TextMeshProUGUI myView;

    void Awake()
    {
        manager.onUpdate += ChangeLang;
    }

    void ChangeLang()
    {        
        myView.text = manager.GetTranslate(ID);
    }
}
