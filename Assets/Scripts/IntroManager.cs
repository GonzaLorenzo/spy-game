using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine.Playables;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    [SerializeField] private PlayableDirector _director;
    [SerializeField] private GameObject _gameplayUI;
    [SerializeField] private GameObject _creditsUI;

    [SerializeField] private CinemachineVirtualCamera _introCamera1;
    [SerializeField] private CinemachineVirtualCamera _introCamera2;
    [SerializeField] private CinemachineVirtualCamera _gameplayCamera;
    [SerializeField] private CinemachineVirtualCamera _finalCamera;
    [SerializeField] private CinemachineVirtualCamera _creditsCamera;

    [SerializeField] private PlayableAsset _creditsTimeline;

    void Start()
    {
        _director.Play();

        MechBoss.onOverheat += SwitchToFinalCamera;
        MechBoss.onDeath += InitCreditsTimeline;
    }

    public void StartGameplayUI()
    {
        _gameplayUI.SetActive(true);
    }

    public void HideGameplayUI()
    {
        _gameplayUI.SetActive(false);
    }

    public void StartCreditsUI()
    {
        _creditsUI.SetActive(true);
        //SwitchCameraPriorityCredits();
    }

    public void SwitchCameraPriority()
    {
        _introCamera1.enabled = false;
        _introCamera2.enabled = false;
        _gameplayCamera.Priority = 12; // 1 mas que la intro camera mas alta que usa 11
    }

    public void SwitchCameraPriorityCredits()
    {
        _introCamera1.enabled = false;
        _introCamera2.enabled = false;
        _finalCamera.Priority = 10;
        _creditsCamera.Priority = 15;
    }

    private void SwitchToFinalCamera()
    {
        _finalCamera.Priority = 15; 
        _gameplayCamera.enabled = false;
    }

    private void InitCreditsTimeline()
    {
        _director.playableAsset = _creditsTimeline;
        _director.Play();
    }
}
