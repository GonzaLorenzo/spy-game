using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour, IInteractable
{
    [SerializeField] Animator _myAnimator;
    [SerializeField] LaserTrap _myLaser;

    public void Interact()
    {
        _myLaser.Deactivate();
        _myAnimator.enabled = true;
    }

}
