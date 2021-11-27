using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VirtualAnalogStick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    protected Image     stick;
    protected Vector2   stickStartPosition;

    [SerializeField]
    protected   Vector2 rawInputVector;
    protected   Vector2 inputVector;
    public Vector2 getInputVector
    {
        get { return inputVector; }
    }

    [SerializeField]
    protected float maxStickDistance;
    protected float sqrStickDistance;

    private void Start()
    {
        stickStartPosition = stick.transform.position;
        sqrStickDistance = maxStickDistance * maxStickDistance;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ResetPosition();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rawInputVector += eventData.delta;
        if (rawInputVector.sqrMagnitude >= sqrStickDistance)
        {
            rawInputVector = rawInputVector.normalized * maxStickDistance;
        }
        inputVector.x = rawInputVector.x / maxStickDistance;
        inputVector.y = rawInputVector.y / maxStickDistance;
        stick.transform.position = stickStartPosition + rawInputVector;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        stick.transform.position = stickStartPosition;
        ResetPosition();
    }

    protected void ResetPosition()
    {
        rawInputVector.x = 0f;
        rawInputVector.y = 0f;
        inputVector.x = 0f;
        inputVector.y = 0f;
    }
}
