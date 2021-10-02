using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperUIFollowEnemy : MonoBehaviour
{
    //public SniperAgro sniperAgro;
    public GameObject sniperAgro;
    Vector3 sniperUIOffset = new Vector3(0.0f, 0.7f, 0.0f);

    private void Awake()
    {
        //sniperAgro.GetComponent<SniperAgro>();
        sniperAgro = GameObject.Find("SniperZone");
       
    }

    private void Update()
    {
        transform.position = sniperAgro.GetComponent<SniperAgro>().selectedEnemy.transform.position + sniperUIOffset;
    }
}
