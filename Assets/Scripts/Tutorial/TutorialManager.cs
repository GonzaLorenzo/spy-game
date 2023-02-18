using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    private Animator _myAnimator;

    [Header("TutorialBoxes")]
    [SerializeField] private GameObject _MovementTutorialBox;

    [Header("Buttons")]
    [SerializeField] private Button _actionButton;
    [SerializeField] private Button _switchButton;
    [SerializeField] private Button _pauseButton;

    [Header("Button GameObjects")]
    [SerializeField] private GameObject _actionGameObject;
    [SerializeField] private GameObject _switchGameObject;
    [SerializeField] private GameObject _pauseGameObject;

    void Start()
    {   
        _myAnimator = GetComponent<Animator>();
        StartMovementTutorial();
    }

    public void StartMovementTutorial()
    {
        _MovementTutorialBox.SetActive(true);
        _myAnimator.Play("VirtualStickFocus");
    }

    public void EndMovementTutorial()
    {
        _myAnimator.StopPlayback();
        _MovementTutorialBox.SetActive(false);
    }

    public void StartShootingTutorial()
    {
        
    }
}
