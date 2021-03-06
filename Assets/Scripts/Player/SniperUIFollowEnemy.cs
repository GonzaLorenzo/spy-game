using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperUIFollowEnemy : MonoBehaviour
{
    
    //public SniperAgro sniperAgro;
    public GameObject sniperAgro;
    //public GameObject audioManager;
    Vector3 sniperUIOffset = new Vector3(0.0f, 0.9f, 0.0f);
    private Animator _myAnimator;
    //private float timeToDestroy = 3f;

    private void Awake()
    {
        //sniperAgro.GetComponent<SniperAgro>();
        sniperAgro = GameObject.Find("SniperZone");
        //audioManager = GameObject.Find("AudioManager");
        _myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.position = sniperAgro.GetComponent<SniperAgro>().selectedEnemy.transform.position + sniperUIOffset;
    }

    public void HasShot()
    {
        _myAnimator.SetTrigger("HasShot");
    }

    private void ActualShot()
    {
        AudioManager.instance.Play("TargetShot");
        
        sniperAgro.GetComponent<SniperAgro>().selectedEnemy.GetComponent<IShootable>().Shoot();

        sniperAgro.GetComponent<SniperAgro>().Enemies.Remove(sniperAgro.GetComponent<SniperAgro>().selectedEnemy);

        Destroy(this.gameObject);

        ReferenceUpdate();       
    }
    
    private void ReferenceUpdate()
    {        
        sniperAgro.GetComponent<SniperAgro>().UpdateTarget();
        Debug.Log("Parte1");
    }

    private void ReferenceSwitchTarget()
    {        
        sniperAgro.GetComponent<SniperAgro>().SwitchTarget();
    }
}
