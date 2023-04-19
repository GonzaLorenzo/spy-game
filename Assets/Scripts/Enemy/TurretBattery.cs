using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBattery : MonoBehaviour, IShootable
{
    [SerializeField] private Turret _myTurret;
    [SerializeField] private ParticleSystem _mySparks;
    [SerializeField] private MeshRenderer _myMeshRenderer;
    [SerializeField] private BoxCollider _boxCollider;
    [SerializeField] private Material _newMaterial;
    private Material[] materials;

    void Start()
    {
        materials = _myMeshRenderer.materials;
    }

    public void Shoot()
    {
        _myTurret.DisableThisTurret();
        materials[1] = _newMaterial;
        _myMeshRenderer.materials = materials;
        _boxCollider.enabled = false;
        _mySparks.Play();
    }
}
