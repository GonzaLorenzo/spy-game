using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;
    private Vector3 _playerPosition;
    private Animator _myAnimator;

    [Header("Tutorial Enemies")]
    [SerializeField] private TankEnemy _tankEnemy;

    [Header("Tutorial Colliders")]
    [SerializeField] private GameObject _distractionTutorialCollider;
    [SerializeField] private GameObject _tankEnemyTutorialCollider;
    [SerializeField] private GameObject _playerTutorialCollider;
    [SerializeField] private GameObject _playerWallCollider;
    [SerializeField] private GameObject _playerBehindWallCollider;

    [Header("TutorialBoxes")]
    [SerializeField] private GameObject _movementTutorialBox;
    [SerializeField] private GameObject _shootingTutorialBox;
    [SerializeField] private GameObject _tankEnemyTutorialBox;
    [SerializeField] private GameObject _distractionTutorialBox;

    [Header("Buttons")]
    [SerializeField] private Button _actionButton;
    [SerializeField] private Button _switchButton;
    [SerializeField] private Button _pauseButton;

    [Header("Button GameObjects")]
    [SerializeField] private GameObject _actionGameObject;
    [SerializeField] private GameObject _switchGameObject;
    [SerializeField] private GameObject _pauseGameObject;

    private int _activatedTutorial;

    void Start()
    {   
        _myAnimator = GetComponent<Animator>();
        StartMovementTutorial();
    }

    public void StartMovementTutorial()
    {
        _playerPosition = _player.transform.position;
        _movementTutorialBox.SetActive(true);
        _myAnimator.Play("VirtualStickFocus");
        StartCoroutine("CheckPlayerPosition");
    }

    public void EndMovementTutorial()
    {
        //_myAnimator.StopPlayback();
        _myAnimator.Play("VirtualStickIdle");
        //_myAnimator.enabled = false;
        _movementTutorialBox.SetActive(false);
    }

    private void StartShootingTutorial()
    {
        _shootingTutorialBox.SetActive(true);
        _actionGameObject.SetActive(true);
        //_myAnimator.enabled = true;
        _myAnimator.Play("ActionButtonFocus");
        _player.CanMove(false);
        _activatedTutorial = 1;
    }

    private void EndShootingTutorial()
    {
        //_myAnimator.StopPlayback();
        _myAnimator.Play("VirtualStickIdle");
        //_myAnimator.enabled = false;
        _shootingTutorialBox.SetActive(false);
        _player.CanMove(true);
        //_distractionTutorialCollider.SetActive(true);
        //_tankEnemy.SwitchCanMove();
    }

    private void StartTankEnemyTutorial()
    {
        _actionButton.interactable = false;
        _tankEnemyTutorialBox.SetActive(true);
        _tankEnemyTutorialCollider.SetActive(false);
        _player.CanMove(false);
        Time.timeScale = 0;
        _activatedTutorial = 2;
    }

    private void EndTankEnemyTutorial()
    {
        _actionButton.interactable = true;
        _tankEnemyTutorialBox.SetActive(false);
        _player.CanMove(true);
        Time.timeScale = 1;
    }

    private void StartDistractionTutorial()
    {
        _myAnimator.Play("ActionButtonFocus");
        _distractionTutorialBox.SetActive(true);
        _distractionTutorialCollider.SetActive(false);
        _player.CanMove(false);
        Time.timeScale = 0;
        _activatedTutorial = 3;
    }

    private void EndDistractionTutorial()
    {
        _myAnimator.Play("VirtualStickIdle");
        _distractionTutorialBox.SetActive(false);
        _distractionTutorialCollider.SetActive(false);
        _playerWallCollider.SetActive(false);
        _player.CanMove(true);
        Time.timeScale = 1;
    }

    public void SetSoldierMoving()
    {
        _tankEnemy.SwitchCanMove();
        _playerTutorialCollider.SetActive(false);
        _playerBehindWallCollider.SetActive(true);
    }

    private void DisableActionButton()
    {
        _actionButton.interactable = false;
    }

    public void StartTutorial(int value)
    {
        switch(value)
        {
            case 1:
                StartShootingTutorial();
                break;
            case 2:
                StartTankEnemyTutorial();
                DisableActionButton();
                break;
            case 3:
                StartDistractionTutorial();
                break;
            case 4:
                SetSoldierMoving();
                break;
        }
    }

    public void EndTutorial()
    {
        switch(_activatedTutorial)
        {
            case 1:
                EndShootingTutorial();
                break;
            case 2:
                EndTankEnemyTutorial();
                break;
            case 3:
                EndDistractionTutorial();
                break;
        }
    }

    IEnumerator CheckPlayerPosition() 
    {
        while (_playerPosition == _player.transform.position)
        {
            yield return null;
        }
        EndMovementTutorial();
        //yield return null;
    }

}

