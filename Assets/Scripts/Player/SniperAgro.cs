﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperAgro : MonoBehaviour
{
    //Osea, si el enemigo o distracción que tengo tiene la interfaz IShootable lo marco con la UI
    //Y con el ActionButton procedo a activarle el Shoot() que mataría el enemigo o activaría la distracción.

    //other.GetComponent<IShootable>().Shoot();

    public GameObject selectedEnemy;
    [SerializeField]
    private GameObject sniperUI;
    public Vector3 spawnPos;
    public Vector3 actualPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IShootable>() != null)
        {
            spawnPos = other.transform.position;
            selectedEnemy = other.gameObject;
            Instantiate(sniperUI);
        }
    }

    public void ShootTarget()
    {
        selectedEnemy.GetComponent<IShootable>().Shoot();
    }
}
