using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashcan : MonoBehaviour, IShootable
{
    [SerializeField]
    private GameObject _myDistractionZone;

    public void Shoot()
    {
        _myDistractionZone.GetComponent<Distraction>().Shoot();
    }
}
