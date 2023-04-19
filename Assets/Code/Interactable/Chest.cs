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
        Inventory inventory = interactor.gameObject.GetComponent<Inventory>();

        if (inventory != null && inventory.HasItem(_prompt))
        {
            Debug.Log("Opening chest!");
            GetComponent<SpriteRenderer>().color = Color.green;
            ShowHint(false);
            Destroy(this);
            return true;
        }
        
        Debug.Log("NO KEY: " + _prompt);
        return false;
    }

    public void ShowHint(bool toShow)
    {
        canvasHint.enabled = toShow;
    }
}
