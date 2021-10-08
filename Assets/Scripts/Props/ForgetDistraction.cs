using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgetDistraction : MonoBehaviour
{
    //Una script solo para esto :(
    private Collider enemy;

    private void OnTriggerEnter(Collider other)
    {
        enemy = other;
        StartCoroutine(LockMovementFor(2));
    }


    private IEnumerator LockMovementFor(float time)
    {
        yield return new WaitForSeconds(time);
        enemy.GetComponent<Enemy>().waypoints.RemoveAt(enemy.GetComponent<Enemy>().waypoints.Count - 1);
    }
    
}
