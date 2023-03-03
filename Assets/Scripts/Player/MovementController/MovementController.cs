using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementController : MonoBehaviour
{
    public abstract Vector3 Move(float VectorX, float VectorZ);
}
