using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperAgro : MonoBehaviour
{
    //Osea, si el enemigo o distracción que tengo tiene la interfaz IShootable lo marco con la UI
    //Y con el ActionButton procedo a activarle el Shoot() que mataría el enemigo o activaría la distracción.

    //other.GetComponent<IShootable>().Shoot();

    private GameObject selectedEnemy;
    private GameObject sniperUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IShootable>() != null)
        {
            //Vector3 pos = ;
            Instantiate(sniperUI, other.transform.position);
        }
    }

    public void ShootTarget()
    {
        selectedEnemy.GetComponent<IShootable>().Shoot();
    }
}
