using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineSniperUI : MonoBehaviour
{
    private GameObject _objective; 
    private AssaultEnemy _enemyObjective;
    private MainMenuTimelineManager _manager;
    Vector3 sniperUIOffset = new Vector3(0.0f, 0.9f, 0.0f);
    private Animator _myAnimator;

    void Awake()
    {
        _myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.position = _objective.transform.position + sniperUIOffset;
    }

    public void HasShot()
    {
        _myAnimator.SetBool("HasShoot", true);
    }

    private void ActualShot()
    {
        AudioManager.instance.Play("TargetShot");
        
        _enemyObjective.Shoot();

        Destroy(this.gameObject);      
    }

    public TimelineSniperUI SetManager(MainMenuTimelineManager manager)
    {
        _manager = manager;

        return this;
    }

    public TimelineSniperUI SetObjective(GameObject objective, AssaultEnemy enemyObjective)
    {
        _objective = objective;
        _enemyObjective = enemyObjective;

        return this;
    }
}
