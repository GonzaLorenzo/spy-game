using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MechBoss : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private GameObject _player;
    private float _speed;
    [SerializeField] private float _increasedSpeed;
    [SerializeField] private float _normalSpeed;
    [SerializeField] private float _decreasedSpeed;
    private int health = 5;

    private CinemachineImpulseSource impulseSource;

    public bool _canMove;

    void Start()
    {
        _speed = _normalSpeed;
        impulseSource = GetComponent<CinemachineImpulseSource>();
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
            //_rb.AddForce(transform.forward * _speed * Time.deltaTime, ForceMode.Force);
            _rb.velocity = transform.forward * _speed * Time.deltaTime;

            //Debug.Log(Vector3.Distance(transform.position, _player.transform.position));

            float distance = Vector3.Distance(transform.position, _player.transform.position);
            
            /* if(distance > 9.5f)
            {
                _speed = _increasedSpeed;
            }
            else if(distance > 6)
            {
                _speed = _normalSpeed;
            }
            else
            {
                _speed = _decreasedSpeed;
            } */

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

    void OnTriggerEnter(Collider other)
    {
        ShootMissiles();
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

    public void ShootMissiles() //Esto pasa cuando choca con un trigger, el trigger le dice tambien a donde van los misiles.
    {
        //Particulas
    }

    public void TakeDamage()
    {
        _animator.SetTrigger("IsHit");
        
        health --;
        if(health <= 0)
        {
            //Animacion muerte.
            //Activar timeline de ganar, llevar la camara a las estrellas y mostrar creditos skipeables.
        }

        //Sonido
        //Capaz hacer que renguee cuando le quede 1 hit.
    }

    public void FootstepShake()
    {
        CameraShakeManager.instance.CameraShake(impulseSource);
    }
}
