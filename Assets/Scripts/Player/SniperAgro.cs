using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SniperAgro : MonoBehaviour
{
    //Osea, si el enemigo o distracción que tengo tiene la interfaz IShootable lo marco con la UI
    //Y con el ActionButton procedo a activarle el Shoot() que mataría el enemigo o activaría la distracción.

    //other.GetComponent<IShootable>().Shoot();

    
    public GameObject selectedEnemy;
    [SerializeField]
    private GameObject sniperUI;
    public Vector3 spawnPos;
    public Vector3 actualPos;
    private GameObject instantiatedUI;
    public List<GameObject> Enemies;
    [SerializeField] private Button _switchButton;
    private int currentEnemy = 0;

    void Start()
    {
        _switchButton = GameObject.Find("SwitchButton").GetComponent<Button>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IShootable>() != null) //&& instantiatedUI == null)
        {
            if(!Enemies.Contains(other.gameObject))
            {
                Enemies.Add(other.gameObject);
            }
            spawnPos = other.transform.position;
            //selectedEnemy = other.gameObject;
            selectedEnemy = Enemies[currentEnemy];

            //GameObject instantiatedUI = Instantiate(sniperUI);
            if (instantiatedUI == null)
            {
                instantiatedUI = Instantiate(sniperUI);
            }
            //Instantiate(sniperUI);
        }
    }

    private void Update()
    {
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

    private void OnTriggerExit(Collider other)
    {
        //Enemies.Remove(selectedEnemy);
        if (other.GetComponent<IShootable>() != null)
        {
            Enemies.Remove(other.gameObject);
            if(Enemies.Count <= 0)
            {
                //Destroy(instantiatedUI);
                UpdateTarget();
                //Debug.Log("Lo hizo el Agro");
            }
        }
    }

    public void ShootTarget()
    {
        if(instantiatedUI != null)
        {

        
        //selectedEnemy.GetComponent<IShootable>().Shoot(); Probar haciendo el shoot desde el UI
        //Hacer la referencia al SniperUIFE para que haga la anim y se destruya en un shoot();
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
            Debug.Log("Parte2");
            instantiatedUI = Instantiate(sniperUI);
            Debug.Log("Parte3");
        }
        else{
            Destroy(instantiatedUI);
        }
    }
}
