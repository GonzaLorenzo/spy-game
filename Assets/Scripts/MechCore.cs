using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechCore : MonoBehaviour, IShootable
{
    public MechBoss mech;

    public void Shoot()
    {
        mech.Die();
    }
}
