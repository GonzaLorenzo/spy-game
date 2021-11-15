using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScreenPause : MonoBehaviour, IScreen
{
    Button[] _buttons;

    string _result;

    private void Awake()
    {
        _buttons = GetComponentsInChildren<Button>();

        foreach(var button in _buttons)
        {
            button.interactable = false;
        }
    }

    public void BTN_Message()
    {
        ScreenManager.Instance.Push("CanvasMessage");
    }
    public void BTN_Back()
    {
        ScreenManager.Instance.Pop();
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
        return _result;
    }
}
