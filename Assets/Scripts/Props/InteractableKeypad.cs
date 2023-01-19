using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableKeypad : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        var screenKeypad = Instantiate(Resources.Load<ScreenKeypad>("KeypadCanvas"));
        ScreenManager.Instance.Push(screenKeypad);
    }

    void OnTriggerEnter(Collider other)
    {
        //Outline activado
    }

    void OnTriggerExit(Collider other)
    {
        //Outline desactivado
    }
}
