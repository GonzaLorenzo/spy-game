using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionSelect : MonoBehaviour
{
    [SerializeField] private Button[] myButtons;

    void OnEnable()
    {
        for (int i = 0; i < MainMenu.completedLevels + 1; i++)
        { 
            myButtons[i].interactable = true;
            Debug.Log(myButtons[i]);   
        }
    }
}
