using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    private Animator _myAnimator;
    private Button _actionButton;

    void Start()
    {   
        _myAnimator = GetComponent<Animator>();
        StartMovementTutorial();
    }

    public void StartMovementTutorial()
    {
        
    }

    public void EndMovementTutorial()
    {
        
    }

    public void StartShootingTutorial()
    {

    }

    public void EndShootingTutorial()
    {

    }
}
