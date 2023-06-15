using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTutorial : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private BoxCollider _collider;
    [SerializeField] private GameObject _interactTutorialBox;

    void OnTriggerEnter(Collider other)
    {
        _player.CanMove(false);
        _interactTutorialBox.SetActive(true);
    }

    public void StopTutorial()
    {
        _player.CanMove(true);
        _collider.enabled = false;
        _interactTutorialBox.SetActive(false);
    }
}
