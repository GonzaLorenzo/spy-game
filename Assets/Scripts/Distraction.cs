using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distraction : MonoBehaviour, IShootable
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
        if (other.GetComponent<IShootable>() != null)
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
        if (other.GetComponent<IShootable>() != null)
        {
            Enemies.Remove(other.gameObject);
        }
    }

    public void Shoot()
    {
        if(selectedEnemy != null)
        selectedEnemy.GetComponent<Enemy>().GetDistracted(myTransform);
    }

}
