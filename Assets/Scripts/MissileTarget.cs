using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTarget : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private SpriteRenderer _sr;

    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
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
    }
}
