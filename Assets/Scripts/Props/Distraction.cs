using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distraction : MonoBehaviour
{
    public GameObject selectedEnemy;
    [SerializeField]
    public List<GameObject> Enemies;
    private int currentEnemy = 0;
    private Transform myTransform;

    private void Awake()
    {
        myTransform = transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() != null)
        {
            if (!Enemies.Contains(other.gameObject))
            {
                Enemies.Add(other.gameObject);
            }
            selectedEnemy = Enemies[currentEnemy];
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Enemy>() != null)
        {
            Enemies.Remove(other.gameObject);
            selectedEnemy = null;
        }
    }

    public void Shoot()
    {
        if(selectedEnemy != null)
        selectedEnemy.GetComponent<Enemy>().GetDistracted(myTransform);
    }

}
