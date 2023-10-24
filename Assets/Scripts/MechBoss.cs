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
            _rb.velocity = transform.forward * _speed * Time.deltaTime;

            //Debug.Log(Vector3.Distance(transform.position, _player.transform.position));

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
        
        if(health < 2)
        {
            _animator.SetBool("IsDamaged", true);
        }
        if(health <= 0)
        {
            Invoke("Overheat", 2f);
        }

        //Sonido
    }

    private void Overheat()
    {
        _animator.SetBool("IsOverheat", true);
        _canMove = false;
        _mechCore.SetActive(true);
        //Se vuelve shooteable, el shooteo final te da el finaltimeline
    }

    public void Die()
    {
        _animator.SetBool("IsDead", true);
        //Sonido muerte.
        //Activar timeline de ganar, llevar la camara a las estrellas y mostrar creditos skipeables.
        //Capaz activar timeline en animationEvent
    }

    public void FootstepShake()
    {
        CameraShakeManager.instance.CameraShake(impulseSource);
    }
}
