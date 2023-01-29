using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageDoors : MonoBehaviour
{
    private Animator _myAnimator;
    private OcclusionPortal[] _myOcclusionPortals;

    void Start()
    {
        _myAnimator = GetComponent<Animator>();    
        _myOcclusionPortals = GetComponentsInChildren<OcclusionPortal>();
    }

    public void OpenDoors()
    {
        foreach (OcclusionPortal portal in _myOcclusionPortals)
        {
            portal.open = true;
        }
        _myAnimator.SetBool("IsOpen", true);
    }
}
