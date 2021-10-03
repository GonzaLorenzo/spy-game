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
    private GameObject instantiatedUI;
    public List<GameObject> Enemies;
    private int currentEnemy = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IShootable>() != null && instantiatedUI == null)
        {
            if(!Enemies.Contains(other.gameObject))
            {
                Enemies.Add(other.gameObject);
            }
            spawnPos = other.transform.position;
            //selectedEnemy = other.gameObject;
            selectedEnemy = Enemies[currentEnemy];
            //GameObject instantiatedUI = Instantiate(sniperUI);
            instantiatedUI = Instantiate(sniperUI);
            //Instantiate(sniperUI);
        }
    }

    private void Update()
    {
        Debug.Log(selectedEnemy);
    }

    private void OnTriggerExit(Collider other)
    {
        Enemies.Remove(selectedEnemy);
        Destroy(instantiatedUI);
    }

    public void ShootTarget()
    {
        //selectedEnemy.GetComponent<IShootable>().Shoot(); Probar haciendo el shoot desde el UI
        //Hacer la referencia al SniperUIFE para que haga la anim y se destruya en un shoot();
        instantiatedUI.GetComponent<SniperUIFollowEnemy>().HasShot();
    }

    public void SwitchTarget()
    {
        if (currentEnemy +1 < Enemies.Count)
        {
            currentEnemy++;
        }
    }
}
