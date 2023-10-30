using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InteractAgro : MonoBehaviour
{
    [SerializeField] private List<IInteractable> _interactableObjectsList = new List<IInteractable>();
    private IInteractable _interactableObject;
    [SerializeField] private Button _interactButton;
    [SerializeField] private GameObject _interactObject;
    [SerializeField] private Animator _interactAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if(!_interactableObjectsList.Contains(other.GetComponent<IInteractable>()))
        {
            _interactableObjectsList.Add(other.GetComponent<IInteractable>());
        }
        
        if(_interactableObjectsList.Count > 0)
        {
            //_interactButton.interactable = true;
            _interactObject.SetActive(true);
            _interactAnimator.SetBool("IsInteracting", true);
        }
        /* else
        {
           //_interactButton.interactable = false;
            _interactObject.SetActive(false);
            _interactAnimator.SetBool("isInteracting", false);
        } */
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<IInteractable>() != null) //&& instantiatedUI == null)
        {
            _interactableObjectsList.Remove(other.GetComponent<IInteractable>());    
        }

        if(_interactableObjectsList.Count == 0)
        {
            //_interactButton.interactable = false;
            _interactObject.SetActive(false);
            _interactAnimator.SetBool("IsInteracting", false);
        }
    }

    public void StopAnimation()
    {
        _interactAnimator.SetBool("IsInteracting", false);
    }

    public void InteractWithTarget()
    {
        if(_interactableObjectsList.Count != 0)
        {
            _interactableObjectsList[0].Interact();
        }
        
    }
}
