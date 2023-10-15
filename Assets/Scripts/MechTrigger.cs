using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechTrigger : MonoBehaviour
{
    [SerializeField] private Missile _missile;
    [SerializeField] private MissileTarget _leftTarget;
    [SerializeField] private MissileTarget _centerTarget;
    [SerializeField] private MissileTarget _rightTarget;

    public bool left;
    public bool center;
    public bool right;

    void OnTriggerEnter(Collider other)
    {
        if(left)
        {
            Vector3 spawnLocation = new Vector3(_leftTarget.transform.position.x, 10, _leftTarget.transform.position.z);
            Instantiate(_missile, spawnLocation, Quaternion.identity).SetTarget(_leftTarget);
            _leftTarget.Activate();
        }
        if(center)
        {
            Vector3 spawnLocation = new Vector3(_centerTarget.transform.position.x, 10, _centerTarget.transform.position.z);
            Instantiate(_missile, spawnLocation, Quaternion.identity).SetTarget(_centerTarget);
            _centerTarget.Activate();
        }
        if(right)
        {
            Vector3 spawnLocation = new Vector3(_rightTarget.transform.position.x, 10, _rightTarget.transform.position.z);
            Instantiate(_missile, spawnLocation, Quaternion.identity).SetTarget(_rightTarget);
            _rightTarget.Activate();
        }
    }
}
