using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecurityCameraLight : MonoBehaviour
{
    public List<Transform> waypoints;
    private int _currentWaypoint = 0;
    SecurityCamera thisCamera;
    [SerializeField]
    private GameObject _securityCamera;
    public Slider detectionBar;
    private SphereCollider _myCollider;
    private int maxDetection = 100;
    private float currentDetection = 0;
    private bool isSeen = false;

    [SerializeField]
    private float speed;
    private bool canResume = true;
    private float stopTime = 2f;

    void Update()
    {
        Move();
    }

    public void Awake()
    {
        detectionBar.value = currentDetection;
        detectionBar.maxValue = maxDetection;
        _myCollider = GetComponent<SphereCollider>();
        thisCamera = _securityCamera.GetComponent<SecurityCamera>();
    }

    private void OnTriggerStay(Collider other)
    {
        isSeen = true;
       
        if (currentDetection < 100)
        {
            currentDetection += 2f;
            detectionBar.value = currentDetection;
        }
        else
        {
            _myCollider.enabled = !_myCollider.enabled;
            SendDetectPlayer();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isSeen = false;
        
        currentDetection = 0f;
        detectionBar.value = currentDetection;
        Debug.Log("No");
    }

    public void SendDetectPlayer()
    {
        thisCamera.DetectPlayer();
    }

    public void EnemyIsDead()
    {
        _myCollider.enabled = !_myCollider.enabled;
        currentDetection = 0f;
        detectionBar.value = currentDetection;
    }

    private void Move()
    {
        if (canResume && waypoints.Count > 0)
        {
            Vector3 dir = waypoints[_currentWaypoint].position - transform.position;
            transform.forward = dir;
            transform.position += transform.forward * speed * Time.deltaTime;

            if (dir.magnitude < 0.1f)
            {
            AwaitInPlace(stopTime);
            _currentWaypoint++;
            if (_currentWaypoint > waypoints.Count - 1)
            _currentWaypoint = 0;
            }
        }
    }

    private void AwaitInPlace(float time)
    {
        StartCoroutine(LockMovementFor(time));
    }
    private IEnumerator LockMovementFor(float time)
    {
        canResume = false;
        yield return new WaitForSeconds(time);
        canResume = true;
    }
}
