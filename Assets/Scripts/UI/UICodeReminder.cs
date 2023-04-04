using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UICodeReminder : MonoBehaviour
{
    [SerializeField] private Text _codeText;
    [SerializeField] private CanvasManager _canvasManager;

    void Awake()
    {
        _codeText.text = "Code: " + _canvasManager._generatedCode.ToString();
    }
}