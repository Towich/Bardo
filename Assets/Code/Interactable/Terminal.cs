using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    
    public string InteractionPrompt { get; }
    
    private Canvas canvasHint;

    private void Start()
    {
        canvasHint = GetComponentInChildren<Canvas>();
        canvasHint.enabled = false;
    }

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Open terminal");
        ShowHint(false);
        return true;
    }

    public void ShowHint(bool toShow) { canvasHint.enabled = toShow; }
}
