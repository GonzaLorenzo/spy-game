﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
//#if UNITY_ANDROID
    [SerializeField] private VirtualAnalogStick virtualStick;
    private Vector3 auxInputVector;
    private Rigidbody _myRigidbody;
    [SerializeField]
    private float _speed;
    //#endif

    private void Awake()
    {
        _myRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (virtualStick.getInputVector.sqrMagnitude > 0f)
        {
            auxInputVector.x = virtualStick.getInputVector.x;
            auxInputVector.z = virtualStick.getInputVector.y;

            transform.LookAt(transform.position + auxInputVector);
            _myRigidbody.MovePosition(_myRigidbody.position + auxInputVector * _speed * Time.deltaTime);
            
        }
    }












}
