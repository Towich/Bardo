using System;
using UnityEngine;

public class Shelves : MonoBehaviour, IInteractable
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
        Debug.Log("Checking the shelves");
        GetComponent<SpriteRenderer>().color = Color.gray;
        ShowHint(false);
        Destroy(this);
        return true;
    }

    public void ShowHint(bool toShow) { canvasHint.enabled = toShow; }
}
