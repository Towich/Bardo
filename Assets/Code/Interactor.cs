using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Interactor class for interaction with <<IInteractable>> objects
/// </summary>
public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint; // center of interactor sphere
    [SerializeField] private float interactionPointRadius; // radius of interactor sphere
    [SerializeField] private LayerMask interactableMask; // mask of Interactable objects

    private readonly Collider2D[] _colliders = new Collider2D[3]; // Interactable objects which interacts with sphere now
    [SerializeField] private int numFound; // num of founded object which interacts with sphere

    private IInteractable showingHintCollider; // object which showing a hint now

    private void Start()
    {
        showingHintCollider = null;
    }

    private void Update()
    {
        // founding Interactable objects in sphere
        numFound = Physics2D.OverlapCircleNonAlloc(interactionPoint.position, interactionPointRadius, _colliders, interactableMask);
        
        
        if (numFound > 0) // if Interactable object founded
            CheckFoundedCollider();
        else if (showingHintCollider != null) // if showing hint now
        {
            showingHintCollider.ShowHint(false); // disable showing hint
            showingHintCollider = null;
        }

    }

    private void CheckFoundedCollider()
    {
        // getting component IInteractable of founded collider (for example: Chest/Door/DeadBody)
        var interactable = _colliders[0].GetComponent<IInteractable>(); 
        
        // if co
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
