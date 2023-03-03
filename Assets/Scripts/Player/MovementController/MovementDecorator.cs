using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementDecorator : MovementController
{
    protected MovementController _movementController;

    public MovementDecorator(MovementController movementController)
    {
        _movementController = movementController;
    }
}
