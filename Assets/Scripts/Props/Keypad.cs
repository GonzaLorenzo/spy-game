using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private ScreenKeypad _myScreen;
    private Image _screen;
    [SerializeField] private List<Text> _screenNumberList = new List<Text>();
    [SerializeField] private List<Button> _buttonList = new List<Button>();
    private CanvasManager _canvasManager;
    private ElectricDoor _electricDoor;
    private int _currentScreenNumber = 0;
    private int _objectiveCombination;

    void Start()
    {
        _myScreen = transform.parent.parent.GetComponent<ScreenKeypad>();
        _screen = transform.GetChild(0).GetComponent<Image>();
        _screenNumberList[0].GetComponent<Animator>().SetBool("IsSelected", true);
        _canvasManager = GameObject.Find("CanvasManager").GetComponent<CanvasManager>();
        _objectiveCombination = _canvasManager._generatedCode;
        _electricDoor = _canvasManager.ElectricDoor;
    }

    private void NextScreenNumber()
    {
        if(_currentScreenNumber + 1 <= 2)
        {
            _screenNumberList[_currentScreenNumber].GetComponent<Animator>().SetBool("IsSelected", false);
            _currentScreenNumber++;
            _screenNumberList[_currentScreenNumber].GetComponent<Animator>().SetBool("IsSelected", true);
        }
        else
        {
            CheckFinalCombination();
        }
    }

    private void DeleteAllNumbers()
    {
        foreach(Text screenNumber in _screenNumberList)
        {
            screenNumber.text = "";
        }
        _screenNumberList[_currentScreenNumber].GetComponent<Animator>().SetBool("IsSelected", false);
        _currentScreenNumber = 0;
        _screenNumberList[_currentScreenNumber].GetComponent<Animator>().SetBool("IsSelected", true);
    }

    private void CheckFinalCombination()
    {
        int finalTry = int.Parse(_screenNumberList[0].text + _screenNumberList[1].text + _screenNumberList[2].text);

        if(finalTry == _objectiveCombination)
        {
            /* _screenNumberList[_currentScreenNumber].GetComponent<Animator>().SetBool("IsSelected", false);
            _electricDoor.OpenDoor();
            _myScreen.BTN_Back(); */

            StartCoroutine("RightCombination");

            //CorrectCombination();
        }
        else
        {
            StartCoroutine("WrongCombination");
        }
          
    }

    public void CloseKeypadButton()
    {
        _animator.SetBool("IsClosed", true);
    }

    private void CorrectCombination()
    {
        _screenNumberList[_currentScreenNumber].GetComponent<Animator>().SetBool("IsSelected", false);
        _animator.SetBool("IsClosed", true);
    }

    private void CloseKeypad()
    {
        _electricDoor.OpenDoor();
        _myScreen.BTN_Back();
    }

    IEnumerator RightCombination()
    {
        _screenNumberList[_currentScreenNumber].GetComponent<Animator>().SetBool("IsSelected", false);
        yield return new WaitForSeconds(0.5f);
        
        //_electricDoor.OpenDoor();
        //_myScreen.BTN_Back();
        CloseKeypadButton();
    }

    IEnumerator WrongCombination()
    {
        foreach (Button buttons in _buttonList)
        {
            buttons.interactable = false;
        }
        _screen.color = new Color32(137,26,0,255);
        _screenNumberList[_currentScreenNumber].GetComponent<Animator>().SetBool("IsSelected", false);

        yield return new WaitForSeconds(1.1f);

        DeleteAllNumbers();
        foreach (Button buttons in _buttonList)
        {
            buttons.interactable = true;
        }
        _screen.color = new Color32(7,154,10,255);
    }

    #region Voids

    public void Type1()
    {
        _screenNumberList[_currentScreenNumber].text = "1";
        NextScreenNumber();
    }
    
    public void Type2()
    {
        _screenNumberList[_currentScreenNumber].text = "2";
        NextScreenNumber();
    }

    public void Type3()
    {
        _screenNumberList[_currentScreenNumber].text = "3";
        NextScreenNumber();
    }

    public void Type4()
    {
        _screenNumberList[_currentScreenNumber].text = "4";
        NextScreenNumber();
    }

    public void Type5()
    {
        _screenNumberList[_currentScreenNumber].text = "5";
        NextScreenNumber();
    }

    public void Type6()
    {
        _screenNumberList[_currentScreenNumber].text = "6";
        NextScreenNumber();
    }

    public void Type7()
    {
        _screenNumberList[_currentScreenNumber].text = "7";
        NextScreenNumber();
    }

    public void Type8()
    {
        _screenNumberList[_currentScreenNumber].text = "8";
        NextScreenNumber();
    }

    public void Type9()
    {
        _screenNumberList[_currentScreenNumber].text = "9";
        NextScreenNumber();
    }

    public void Type0()
    {
        _screenNumberList[_currentScreenNumber].text = "0";
        NextScreenNumber();
    }

    #endregion
}
