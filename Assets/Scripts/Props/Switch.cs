using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour, IInteractable
{
    [SerializeField] Animator _myAnimator;
    [SerializeField] List<LaserTrap> _myLasers;

    public void Interact()
    {
        foreach(LaserTrap laser in _myLasers)
        {
            laser.Deactivate();
        }
        _myAnimator.enabled = true;
    }

}
