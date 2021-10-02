using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperUIFollowEnemy : MonoBehaviour
{
    //public SniperAgro sniperAgro;
    public GameObject sniperAgro;
    

    private void Awake()
    {
        //sniperAgro.GetComponent<SniperAgro>();
        sniperAgro = GameObject.Find("SniperZone");
       
    }

    private void Update()
    {
        transform.position = sniperAgro.GetComponent<SniperAgro>().actualPos;
    }
}
