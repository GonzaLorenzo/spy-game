using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MissileTarget : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private ParticleSystem _explosion1;
    [SerializeField] private ParticleSystem _explosion2;

    private SpriteRenderer _sr;
    private AudioSource _as;
    private CinemachineImpulseSource impulseSource;

    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _as = GetComponent<AudioSource>();
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, _player.position.z);
    }

    public void Activate()
    {
        _sr.enabled = true;
    }

    public void Deactivate()
    {
        _sr.enabled = false;
        _explosion1.Play();
        _explosion2.Play();
        _as.Play();
        CameraShakeManager.instance.CameraShake(impulseSource);
    }
}
