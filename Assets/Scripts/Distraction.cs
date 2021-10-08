using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distraction : MonoBehaviour, IShootable
{
    public GameObject selectedEnemy;
    [SerializeField]
    public List<GameObject> Distractables;
    private int currentEnemy = 0;
    private Transform myTransform;

    private void Awake()
    {
        myTransform = transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entró este conchesumadre" + other);
        if (other.GetComponent<IShootable>() != null)
        {
            if (!Distractables.Contains(other.gameObject))
            {
                Distractables.Add(other.gameObject);
            }

            selectedEnemy = Distractables[currentEnemy];
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<IShootable>() != null)
        {
            Distractables.Remove(other.gameObject);
        }
    }

    public void Shoot()
    {
        //if(selectedEnemy != null)
        selectedEnemy.GetComponent<Enemy>().GetDistracted(myTransform);
    }

}
