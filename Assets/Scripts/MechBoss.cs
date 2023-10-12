using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechBoss : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed;
    public bool _canMove;

    void FixedUpdate()
    {
        if(_canMove)
        {
            Debug.Log("Hola");

            //_rb.AddForce(transform.forward * _speed * Time.deltaTime, ForceMode.Force);
            _rb.velocity = transform.forward * _speed * Time.deltaTime;

            Debug.Log(Vector3.Distance(transform.position, _player.transform.position));

            //Ver de regular la velocidad dependiendo de la distancia.
            //Con speed en 145 mantiene la distancia con el jugador.
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

    public void ShootMissiles() //Esto pasa cuando choca con un trigger, el trigger le dice tambien a donde van los misiles.
    {
        //Dispara los misiles
        //Particulas
        //Activar el indicador de donde caen los misiles
    }
}
