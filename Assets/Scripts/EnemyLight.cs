using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLight : MonoBehaviour
{
    Enemy thisEnemy;
    public Slider staminaBar;

    public void Awake()
    {
        
    }

    private void Update()
    {

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
