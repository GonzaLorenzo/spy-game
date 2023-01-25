using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageDoors : MonoBehaviour
{
    private Animator _myAnimator;

    void Start()
    {
        _myAnimator = GetComponent<Animator>();    
    }

    public void OpenDoors()
    {
        _myAnimator.SetBool("IsOpen", true);
    }
}
