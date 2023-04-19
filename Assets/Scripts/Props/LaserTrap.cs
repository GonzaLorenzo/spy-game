using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrap : MonoBehaviour
{
    [SerializeField] private GameObject _electricArc;

    public void Deactivate()
    {
        _electricArc.SetActive(false);
    }
}
