using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenPaper : MonoBehaviour, IScreen
{
    private int _codeIndex;
    public delegate void ShowCode(int codeToShow);
    public static event ShowCode ShowCodeEvent;
    Button[] _buttons;

    private void Awake()
    {
        _buttons = GetComponentsInChildren<Button>();

        foreach(var button in _buttons)
        {
            button.interactable = false;
        }
    }

    public void BTN_Back()
    {
        ScreenManager.Instance.Pop();
        ShowCodeEvent(_codeIndex);
    }

    public void Activate()
    {
        foreach(var button in _buttons)
        {
            button.interactable = true;
        }
    }

    public void Deactivate()
    {
        foreach(var button in _buttons)
        {
            button.interactable = false;
        }
    }

    public string Free()
    {
        Destroy(gameObject);
        return "WinScreen ded :c";
    }

    public ScreenPaper SetCodeIndex(int codeIndex)
    {
        _codeIndex = codeIndex;
        return this;
    }
}
