using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCollider : MonoBehaviour
{
    [SerializeField] private TutorialManager _manager;
    [SerializeField] private int _tutorial;
    void OnTriggerEnter(Collider other)
    {
        _manager.StartTutorial(_tutorial);
    }
}
