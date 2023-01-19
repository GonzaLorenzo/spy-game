using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //#if UNITY_ANDROID
    [SerializeField] private DataManager dataManager;
    [SerializeField] private VirtualAnalogStick virtualStick;
    private Vector3 auxInputVector;
    private Rigidbody _myRigidbody;
    private Animator _myAnimator;
    [SerializeField] private float _speed = 3;
    //#endif

    private void Awake()
    {
        virtualStick = GameObject.Find("VirtualStick").GetComponent<VirtualAnalogStick>();
        _myRigidbody = GetComponent<Rigidbody>();
        _myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
            if (virtualStick.getInputVector.sqrMagnitude > 0f)
            {
                _myAnimator.SetBool("IsMoving", true);

                auxInputVector.x = virtualStick.getInputVector.x;
                auxInputVector.z = virtualStick.getInputVector.y;

                transform.LookAt(transform.position + auxInputVector);
                _myRigidbody.MovePosition(_myRigidbody.position + auxInputVector * _speed * Time.deltaTime);

            }
            else
            {
                _myAnimator.SetBool("IsMoving", false);
            }
    }

    public void ChangeSpeed(float speedMultiplier)
    {
        /* if(_speed * speedMultiplier > 4.5f)
        {
            _speed = 4.5f;
        }
        else
        {
            _speed *= speedMultiplier;
        } */
        _speed = Math.Max(_speed * speedMultiplier, 4.5f);

        dataManager.Save();
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public float GetSpeed()
    {
        return _speed;
    }

    public void ResetSpeed()
    {
        _speed = 3f;
        dataManager.Save();
    }
}
