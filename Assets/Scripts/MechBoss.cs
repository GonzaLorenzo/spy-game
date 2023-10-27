using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MechBoss : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _mechCore;

    [Header("Particles")]
    [SerializeField] private ParticleSystem _missileParticles1;
    [SerializeField] private ParticleSystem _missileParticles2;
    [SerializeField] private ParticleSystem _leftFootPartciles;
    [SerializeField] private ParticleSystem _rightFootParticles;

    private float _speed;

    [Header("Speed")]
    [SerializeField] private float _increasedSpeed;
    [SerializeField] private float _normalSpeed;
    [SerializeField] private float _decreasedSpeed;
    
    private int health = 5;
    private CinemachineImpulseSource impulseSource;
    private bool _canMove;

    public delegate void OnOverheat();
    public static event OnOverheat onOverheat;

    public delegate void OnDeath();
    public static event OnDeath onDeath;

    void Start()
    {
        _speed = _normalSpeed;
        impulseSource = GetComponent<CinemachineImpulseSource>();

        MechTrigger.onTrigger += ShootMissiles;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage();
        }
    }

    void FixedUpdate()
    {
        if(_canMove)
        {
            _rb.velocity = transform.forward * _speed * Time.deltaTime;

            float distance = Vector3.Distance(transform.position, _player.transform.position);

            if(distance > 9.5f)
            {
                _speed = _increasedSpeed;
            }
            else
            {
                _speed = _decreasedSpeed;
            }
        }
    }

    public void StartMechAnim()
    {
        _animator.SetBool("IsAlive", true);
    }

    public void SetMove()
    {
        _animator.SetBool("IsMoving", true);
        _canMove = true;
    }

    public void ShootMissiles()
    {
        _missileParticles1.Play();
        _missileParticles2.Play();

        //Sonido.
    }

    public void TakeDamage()
    {
        _animator.SetTrigger("IsHit");
        
        health --;
        
        if(health < 2)
        {
            _animator.SetBool("IsDamaged", true);
        }
        if(health <= 0)
        {
            Invoke("Overheat", 1.3f);
        }

        //Sonido
    }

    private void Overheat()
    {
        _animator.SetBool("IsOverheat", true);
        _canMove = false;
        _mechCore.SetActive(true);
        onOverheat();
    }

    public void Die()
    {
        _animator.SetBool("IsDead", true);
        //Invoke("onDeath", 1.5f);
        onDeath();
        //Sonido muerte.
        //Activar timeline de ganar, llevar la camara a las estrellas y mostrar creditos skipeables.
        //Capaz activar timeline en animationEvent
    }

    public void FootstepShake(int foot) // 0 = left || 1 = right
    {
        CameraShakeManager.instance.CameraShake(impulseSource);

        if(foot == 0)
        {
            _leftFootPartciles.Play();
        }
        else
        {
            _rightFootParticles.Play();
        }
        //Sonido.
    }
}
