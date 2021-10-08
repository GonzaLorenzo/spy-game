using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
//#if UNITY_ANDROID
    [SerializeField] private VirtualAnalogStick virtualStick;
    private Vector3 auxInputVector;
    private Rigidbody _myRigidbody;
    private Animator _myAnimator;
    [SerializeField]
    private float _speed = 3f;
    //#endif

    private void Awake()
    {
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












}
