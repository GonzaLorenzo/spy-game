using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechBoss : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private GameObject _player;
    [SerializeField] private Missile _missile;
    private float _speed;
    [SerializeField] private float _increasedSpeed;
    [SerializeField] private float _normalSpeed;
    private int health = 5;

    public bool _canMove;

    void Start()
    {
        _speed = _normalSpeed;
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
            
            if(distance > 9.5f)
            {
                _speed = _increasedSpeed;
            }
            else
            {
                _speed = _normalSpeed;
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
        Debug.Log("Hola");
        health --;
        if(health <= 0)
        {
            //Animacion muerte.
            //Activar timeline de ganar, llevar la camara a las estrellas y mostrar creditos skipeables.
        }

        //Animacion de hit, hacer que tenga animationmask o avatarmask eso para que solo afecte al torso.
        //Capaz hacer que renguee cuando le quede 1 hit.
    }
}
