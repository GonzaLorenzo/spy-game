using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLight : MonoBehaviour
{
    public GameObject thisEnemy;

    public void Awake()
    {
        thisEnemy = transform.parent.gameObject;
    }

    private void Update()
    {
        Debug.Log(thisEnemy);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("holi");
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

    public void DetectPlayer()
    {

    }
}
