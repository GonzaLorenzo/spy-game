using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLight : MonoBehaviour
{
    Enemy thisEnemy;
    public Slider detectionBar;
    private CapsuleCollider _myCollider;

    [SerializeField]
    private float maxDetection = 100;
    private float currentDetection = 0;
    private bool isSeen = false;

    public void Awake()
    {
        detectionBar.value = currentDetection;
        detectionBar.maxValue = maxDetection;
        _myCollider = GetComponent<CapsuleCollider>();
        thisEnemy = transform.parent.GetComponent<Enemy>();
    }

    private void OnTriggerStay(Collider other)
    {
        isSeen = true;
       
        if (currentDetection < maxDetection)
        {
            currentDetection += 2.4f; // + Time.deltaTime * detec
            detectionBar.value = currentDetection;
            //Debug.Log("Te veo" + currentDetection);
        }
        else
        {
            _myCollider.enabled = !_myCollider.enabled;
            SendDetectPlayer();
            //_myCollider.enabled = !_myCollider.enabled;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isSeen = false;
        
        currentDetection = 0f;
        detectionBar.value = currentDetection;
    }

    public void SendDetectPlayer()
    {
        thisEnemy.DetectPlayer();
    }

    public void EnemyIsDead()
    {
        _myCollider.enabled = !_myCollider.enabled;
        currentDetection = 0f;
        detectionBar.value = currentDetection;
    }
}
