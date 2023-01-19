using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CodePaperUI : MonoBehaviour
{
    private Text _codeText;
    private CanvasManager _canvasManager;

    void Start()
    {
        _codeText = transform.GetChild(0).GetComponent<Text>();
        _canvasManager = GameObject.Find("CanvasManager").GetComponent<CanvasManager>();

        _codeText.text = "Code: " + _canvasManager._generatedCode.ToString();
    }
}
