using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //#if UNITY_ANDROID
    private MovementController _movementStats;
    [SerializeField] private DataManager dataManager;
    [SerializeField] private VirtualAnalogStick virtualStick;
    private Vector3 auxInputVector;
    private Rigidbody _myRigidbody;
    private Animator _myAnimator;
    [SerializeField] private float _speed = 3;

    private bool _canMove = true;
    private bool _switchedMovement = false;
    //#endif

    private void Awake()
    {
        _myRigidbody = GetComponent<Rigidbody>();
        _myAnimator = GetComponent<Animator>();
        _movementStats = new MovementStats();
    }

    private void Update()
    {
        if (virtualStick.getInputVector.sqrMagnitude > 0f && _canMove)
        {
            _myAnimator.SetBool("IsMoving", true);

            //auxInputVector.x = virtualStick.getInputVector.x;
            //auxInputVector.z = virtualStick.getInputVector.y;

            auxInputVector = _movementStats.Move(virtualStick.getInputVector.x, virtualStick.getInputVector.y);
            
            transform.LookAt(transform.position + auxInputVector);
            _myRigidbody.MovePosition(_myRigidbody.position + auxInputVector * _speed * Time.deltaTime);
        }
        else
        {
            _myAnimator.SetBool("IsMoving", false);
        }
    }

    public void SetMovementController(MovementController newStats)
    {
        _movementStats = newStats;
    }

    public void CanMove(bool value)
    {
        _canMove = value;
    }

    public void ApplyRootMotion() //Deshabilite root motion en el animator para poder usar el timeline pero ahora hay que habilitarlo de nuevo para poder jugar.
    {
        _myAnimator.applyRootMotion = true;
    }
}
