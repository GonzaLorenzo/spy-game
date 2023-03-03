using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStats : MovementController
{
    public override Vector3 Move(float VectorX, float VectorZ)
    {
        return new Vector3(VectorX, 0, VectorZ);
    }
}
