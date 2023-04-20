using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashcan : MonoBehaviour, IShootable
{
    [SerializeField] private GameObject _myDistractionZone;
    [SerializeField] private ParticleSystem _sparksParticle;

    public void Shoot()
    {
        _myDistractionZone.GetComponent<Distraction>().Shoot();
        _sparksParticle.Play();
    }
}
