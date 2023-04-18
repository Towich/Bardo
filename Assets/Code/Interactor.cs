using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius;
    [SerializeField] private LayerMask interactableMask;

    private readonly Collider2D[] _colliders = new Collider2D[3];
    [SerializeField] private int numFound;

    private IInteractable showingHintCollider;

    private void Start()
    {
        showingHintCollider = null;
    }

    private void Update()
    {
        numFound = Physics2D.OverlapCircleNonAlloc(interactionPoint.position, interactionPointRadius, _colliders, interactableMask);
        
        
        if (numFound > 0)
            CheckFoundedCollider();
        else if (showingHintCollider != null)
        {
            showingHintCollider.ShowHint(false);
            showingHintCollider = null;
        }

    }

    private void CheckFoundedCollider()
    {
        var interactable = _colliders[0].GetComponent<IInteractable>(); // getting component IInteractable of founded collider (for example: Chest/Door)
        
        if (interactable != null)
        {
            interactable.ShowHint(true);
            showingHintCollider = interactable;
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactable.Interact(this);
            }
        }
        
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);
    }
}
