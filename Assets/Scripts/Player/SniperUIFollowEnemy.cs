using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperUIFollowEnemy : MonoBehaviour
{
    //public SniperAgro sniperAgro;
    public GameObject sniperAgro;

    private void Awake()
    {
        sniperAgro.GetComponent<SniperAgro>();
    }

    private void Update()
    {
        //transform.position = sniperAgro.spawnPos;
    }
}
