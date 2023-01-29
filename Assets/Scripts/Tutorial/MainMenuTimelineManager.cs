using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine.Playables;
using UnityEngine;

public class MainMenuTimelineManager : MonoBehaviour
{
    private PlayableDirector _director;
    [SerializeField] private CinemachineVirtualCamera _introCamera1;
    [SerializeField] private CinemachineVirtualCamera _introCamera2;
    [SerializeField] private CinemachineVirtualCamera _gameplayCamera;
    [SerializeField] private Animator _mainMenuButtonsAnimator;

    [Header("Soldier")] 
    [SerializeField] private AssaultEnemy _soldier1;
    [SerializeField] private AssaultEnemy _soldier2;

    [Header("UI")] 
    [SerializeField] private TimelineSniperUI _sniperUI;
    [SerializeField] private GameObject _panelUI;
    [SerializeField] private GameObject _menuUI;
    [SerializeField] private GameObject _gameplayUI;

    void Start()
    {
        _director = GetComponent<PlayableDirector>();    
    }

    public void HideMainMenuButtons()
    {
        _mainMenuButtonsAnimator.SetTrigger("IsPlaying");
    }

    public void KillIntroSoldiers()
    {
        var sniperUI1 = Instantiate(_sniperUI).SetManager(this).SetObjective(_soldier1.gameObject, _soldier1);
        var sniperUI2 = Instantiate(_sniperUI).SetManager(this).SetObjective(_soldier2.gameObject, _soldier2);

        sniperUI1.HasShot();
        sniperUI2.HasShot();

        _director.Play();
    }

    public void StartGameplayUI()
    {
        _panelUI.SetActive(false);
        _menuUI.SetActive(false);
        _gameplayUI.SetActive(true);
    }

    public void SwitchCameraPriority()
    {
        _introCamera1.enabled = false;
        _introCamera2.enabled = false;
        _gameplayCamera.Priority = 12; // 1 mas que la intro camera mas alta que usa 11
    }
}
