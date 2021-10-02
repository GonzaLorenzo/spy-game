using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperUIFollowEnemy : MonoBehaviour
{
    public SniperAgro sniperAgro;

    private void Update()
    {
        transform.position = sniperAgro.spawnPos;
    }
}
