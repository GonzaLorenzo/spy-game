using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricDoor : MonoBehaviour
{
    private Animator _myAnimator;

    void Start()
    {
        _myAnimator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        _myAnimator.SetBool("IsOpened", true);
    }
}
