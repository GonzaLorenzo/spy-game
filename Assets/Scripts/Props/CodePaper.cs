using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodePaper : MonoBehaviour, IInteractable
{
    [SerializeField] private int _codeIndex;
    public void Interact()
    {
        var screenPaper = Instantiate(Resources.Load<ScreenPaper>("PaperCanvas"));
        ScreenManager.Instance.Push(screenPaper);
        screenPaper.SetCodeIndex(_codeIndex);
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
