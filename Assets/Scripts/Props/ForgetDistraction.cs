using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgetDistraction : MonoBehaviour
{
    //Una script solo para esto :(
    private GameObject enemy;

    private void OnTriggerEnter(Collider other)
    {
        enemy = other.gameObject;
        StartCoroutine(DistractFor(2));
    }


    private IEnumerator DistractFor(float time)
    {
        yield return new WaitForSeconds(time);
        //enemy.GetComponent<Enemy>().waypoints.RemoveAt(enemy.GetComponent<Enemy>().waypoints.Count - 1); Usar referencia a Void del Enemy.
        enemy.GetComponent<Enemy>().ForgetDistraction();
    }
    
}
