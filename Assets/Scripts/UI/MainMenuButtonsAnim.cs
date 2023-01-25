﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;

public class MainMenuButtonsAnim : MonoBehaviour
{
    [SerializeField] MainMenuTimelineManager _timelineManager;
    private Button[] _buttons;
    void Start()
    {
       _buttons = GetComponentsInChildren<Button>();
    }

    public void ActivateButtons() //Se activa con evento en la animacion inicial.
    {
        foreach(Button button in _buttons)
        {
            button.interactable = true;
        }
    }

    public void AnimationEnded()
    {
        _timelineManager.KillIntroSoldiers();
    }
}
