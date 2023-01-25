using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine;

public class MainMenuTimelineManager : MonoBehaviour
{
    private PlayableDirector _director;
    [SerializeField] private Animator _mainMenuButtonsAnimator;

    [Header("Soldier")] 
    [SerializeField] private AssaultEnemy _soldier1;
    [SerializeField] private AssaultEnemy _soldier2;

    [SerializeField] private TimelineSniperUI _sniperUI;

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
}
