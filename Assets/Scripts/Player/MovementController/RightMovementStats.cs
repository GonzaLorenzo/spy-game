using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMovementStats : MovementDecorator
{
    public RightMovementStats(MovementController movementController) : base(movementController)
    {

    }

    public override Vector3 Move(float VectorX, float VectorZ)
    {
        return new Vector3(VectorZ, 0, -VectorX);
    }
}
