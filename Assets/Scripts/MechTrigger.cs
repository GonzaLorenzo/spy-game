using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechTrigger : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    [SerializeField] private Missile _missile;
    [SerializeField] private MissileTarget _leftTarget;
    [SerializeField] private MissileTarget _centerTarget;
    [SerializeField] private MissileTarget _rightTarget;

    public delegate void OnTrigger();
    public static event OnTrigger onTrigger;

    public bool left;
    public bool center;
    public bool right;

    void OnTriggerEnter(Collider other)
    {
        if(left)
        {
            Vector3 spawnLocation = new Vector3(_leftTarget.transform.position.x, 18.5f, _leftTarget.transform.position.z);
            Instantiate(_missile, spawnLocation, Quaternion.identity, _parent).SetTarget(_leftTarget);
            _leftTarget.Activate();
        }
        if(center)
        {
            Vector3 spawnLocation = new Vector3(_centerTarget.transform.position.x, 18.5f, _centerTarget.transform.position.z);
            Instantiate(_missile, spawnLocation, Quaternion.identity, _parent).SetTarget(_centerTarget);
            _centerTarget.Activate();
        }
        if(right)
        {
            Vector3 spawnLocation = new Vector3(_rightTarget.transform.position.x, 18.5f, _rightTarget.transform.position.z);
            Instantiate(_missile, spawnLocation, Quaternion.identity, _parent).SetTarget(_rightTarget);
            _rightTarget.Activate();
        }

        onTrigger();
    }
}
