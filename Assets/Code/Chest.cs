using System;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    
    public string InteractionPrompt => _prompt;

    private Canvas canvasHint;

    private void Start()
    {
        canvasHint = GetComponentInChildren<Canvas>();
        canvasHint.enabled = false;
    }

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Opening chest!");
        GetComponent<SpriteRenderer>().color = Color.green;
        return true;
    }

    public void ShowHint(bool toShow)
    {
        canvasHint.enabled = toShow;
    }
}
