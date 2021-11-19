using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void PauseGame()
    {
        var screenPause = Instantiate(Resources.Load<ScreenPause>("PauseCanvas"));
        ScreenManager.Instance.Push(screenPause);
    }
}
