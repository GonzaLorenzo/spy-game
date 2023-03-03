﻿using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class StandardCameraSwitcher : MonoBehaviour
{
    private MovementController _movementStats = new MovementStats();
    [SerializeField] private PlayerMovement _player;
    [Header("Camera")] 
    [SerializeField] private CinemachineVirtualCamera _firstCamera;
    [SerializeField] private CinemachineVirtualCamera _secondCamera;

    void Start()
    {
        _movementStats = new MovementStats();
    }

    void OnTriggerEnter(Collider other)
    {
        _firstCamera.enabled = false;
        _secondCamera.enabled = true;
        _player.SetMovementController(_movementStats);
        Destroy(this.gameObject);
    }
}
