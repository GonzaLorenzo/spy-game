using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SniperAgro : MonoBehaviour
{
    public GameObject selectedEnemy;
    [SerializeField] private GameObject sniperUI;
    public Vector3 spawnPos;
    public Vector3 actualPos;
    private GameObject instantiatedUI;
    public List<GameObject> Enemies;
    [SerializeField] private Button _switchButton;
    private bool _laserIsFixed;
    [SerializeField] private LineRenderer _laser;
    [SerializeField] private GameObject _laserObject;
    private int currentEnemy = 0;

    [Header("Laser Movement Values")]
    [SerializeField] private float _laserSpeed;
    [SerializeField] private float _maxOffsetY;
    private float _laserOffsetY;
    [SerializeField] private float _maxOffsetX;
    private float _laserOffsetX;

    void Start()
    {
        _laserOffsetX = _maxOffsetX;
        _laserOffsetY = _maxOffsetY;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IShootable>() != null)
        {
            if(!Enemies.Contains(other.gameObject))
            {
                Enemies.Add(other.gameObject);
            }
            spawnPos = other.transform.position;

            selectedEnemy = Enemies[currentEnemy];

            _laserObject.SetActive(true);
            _laser.SetPosition(0, new Vector3(transform.position.x, transform.position.y + 10, transform.position.z));
            _laser.SetPosition(1, new Vector3(selectedEnemy.transform.position.x, selectedEnemy.transform.position.y + 1, selectedEnemy.transform.position.z));

            _laserIsFixed = true;
            
            if (instantiatedUI == null)
            {
                instantiatedUI = Instantiate(sniperUI);
            }
        
            if(Enemies.Count >= 2)
            {
                _switchButton.interactable = true;
            }
            else
            {
                _switchButton.interactable = false;
            }
        }
    }

    private void Update()
    {
        if(_laserIsFixed)
        {
            _laser.SetPosition(0, new Vector3(transform.position.x + 2, transform.position.y + 10, transform.position.z - 10));
            _laserOffsetY = Mathf.Lerp(_laserOffsetY, 1, _laserSpeed * Time.deltaTime);
            _laserOffsetX = Mathf.Lerp(_laserOffsetX, 0, _laserSpeed * Time.deltaTime);
            _laser.SetPosition(1, new Vector3(selectedEnemy.transform.position.x + _laserOffsetX, selectedEnemy.transform.position.y + _laserOffsetY, selectedEnemy.transform.position.z));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<IShootable>() != null)
        {
            Enemies.Remove(other.gameObject);
            if(Enemies.Count <= 0)
            {
                UpdateTarget();
            }
        }

        if(Enemies.Count == 0)
        {
            UpdateTarget();
        }
        
        if(Enemies.Count >= 2)
        {
            _switchButton.interactable = true;
        }
        else
        {
            _switchButton.interactable = false;
        }
    }

    public void ShootTarget()
    {
        if(instantiatedUI != null)
        {
            instantiatedUI.GetComponent<SniperUIFollowEnemy>().HasShot();
        }
    }

    public void SwitchTarget()
    {
        if (currentEnemy +1 < Enemies.Count)
        {
            currentEnemy++;
            selectedEnemy = Enemies[currentEnemy];
        }
        else
        {
            currentEnemy = 0;
            selectedEnemy = Enemies[currentEnemy];
        }
    }

    public void UpdateTarget() //Donde pongo esto? - Ya encontré donde :)
    {
        if(Enemies.Count > 0) //&& instantiatedUI == null)
        {
            currentEnemy = 0;
            selectedEnemy = Enemies[currentEnemy];
            instantiatedUI = Instantiate(sniperUI);
        }
        else
        {
            Destroy(instantiatedUI);
            _laserObject.SetActive(false);
            _laserOffsetX = _maxOffsetX;
            _laserOffsetY = _maxOffsetY;
            _laserIsFixed = false;
        }
    }
}
