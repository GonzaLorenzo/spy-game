using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasTankTrigger : MonoBehaviour
{
    [SerializeField] private MechBoss _mech;
    private BoxCollider _bc;

    void Start()
    {
        _bc = GetComponent<BoxCollider>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Choque con " + other.name);
        _mech.TakeDamage();
        _bc.enabled = false;
    }
}
