using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperUIFollowEnemy : MonoBehaviour
{
    private SniperAgro _sniperAgro;
    Vector3 sniperUIOffset = new Vector3(0.0f, 0.9f, 0.0f);
    private Animator _myAnimator;

    private void Awake()
    {
        //sniperAgro.GetComponent<SniperAgro>();
        _sniperAgro = GameObject.Find("SniperZone").GetComponent<SniperAgro>();
        //audioManager = GameObject.Find("AudioManager");
        _myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        //if()
        transform.position = _sniperAgro.selectedEnemy.transform.position + sniperUIOffset;
    }

    public void HasShot()
    {
        _myAnimator.SetBool("HasShoot", true);
    }

    private void ActualShot()
    {
        AudioManager.instance.Play("TargetShot");
        
        _sniperAgro.selectedEnemy.GetComponent<IShootable>().Shoot();
        
        if(_sniperAgro.selectedEnemy.GetComponent<Trashcan>() != true)
        {
            _sniperAgro.Enemies.Remove(_sniperAgro.selectedEnemy);
        }

        Destroy(this.gameObject); //Destruir pero mantener el tacho en la lista.

        ReferenceUpdate();       
    }
    
    private void ReferenceUpdate()
    {   
        _myAnimator.SetBool("HasShoot", false);
        _sniperAgro.UpdateTarget();
    }

    private void ReferenceSwitchTarget()
    {        
        _sniperAgro.SwitchTarget();
    }
}

