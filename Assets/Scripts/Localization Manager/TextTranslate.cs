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

    private void Awake()
    {
        manager.onUpdate += ChangeLang;
    }

    void Start()
    {
        ChangeLang();
    }

    private void OnEnable() 
    {
        ChangeLang(); //Después crear IScene de menú o darle un tiempo para ponerse en enable con anim
    }

    void ChangeLang()
    {        
        myView.text = manager.GetTranslate(ID);
    }
}
