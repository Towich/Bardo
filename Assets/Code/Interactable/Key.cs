using System;
using UnityEngine;

public class Key : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt { get; }
    public GameObject prefabUI;
    
    private Canvas canvasHint;

    private void Start()
    {
        canvasHint = GetComponentInChildren<Canvas>();
        canvasHint.enabled = false;
    }

    public bool Interact(Interactor interactor)
    {
        Inventory inventory = interactor.gameObject.GetComponent<Inventory>();

        if (inventory != null)
        {
            Debug.Log("Added " + _prompt + "!");
            inventory.AddItem(prefabUI);
            Destroy(gameObject);
            return true;
        }

        return false;
    }

    public void ShowHint(bool toShow)
    {
        if(canvasHint != null)
            canvasHint.enabled = toShow;
    }
}
