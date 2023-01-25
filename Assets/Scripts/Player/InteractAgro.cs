﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InteractAgro : MonoBehaviour
{
    [SerializeField] private List<IInteractable> _interactableObjectsList = new List<IInteractable>();
    private IInteractable _interactableObject;
    [SerializeField] private Button _interactButton;

    void Start()
    {
        //_interactButton = GameObject.Find("InteractButton").GetComponent<Button>(); Setear manualmente.
    }

    void Update()
    {
        /* if(_interactableObjectsList.Count > 0)
        {
            _interactButton.interactable = true;
        }
        else
        {
            _interactButton.interactable = false;
        } */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IInteractable>() != null) //&& instantiatedUI == null)
        {
            if(!_interactableObjectsList.Contains(other.GetComponent<IInteractable>()))
            {
                _interactableObjectsList.Add(other.GetComponent<IInteractable>());
            }
        }

        if(_interactableObjectsList.Count > 0)
        {
            _interactButton.interactable = true;
        }
        else
        {
            _interactButton.interactable = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<IInteractable>() != null) //&& instantiatedUI == null)
        {
            _interactableObjectsList.Remove(other.GetComponent<IInteractable>());    
        }

        if(_interactableObjectsList.Count > 0)
        {
            _interactButton.interactable = true;
        }
        else
        {
            _interactButton.interactable = false;
        }
    }

    public void InteractWithTarget()
    {
        _interactableObjectsList[0].Interact();
    }
}
