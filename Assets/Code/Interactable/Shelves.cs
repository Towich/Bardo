using System;
using System.Collections;
using UnityEngine;

public class Shelves : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject prefabUI;
    [SerializeField] private string _prompt;
    
    public string InteractionPrompt { get; }
    
    private Canvas canvasHint;
    private Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        canvasHint = GetComponentInChildren<Canvas>();
        canvasHint.enabled = false;
    }

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Checking the shelves");
        
        Inventory inventory = interactor.gameObject.GetComponent<Inventory>();
        PlayerController pl = interactor.gameObject.GetComponent<PlayerController>();

        StartCoroutine(LootingShelves(inventory, pl));
        
        return true;
    }

    public void ShowHint(bool toShow) { canvasHint.enabled = toShow; }
    
    private IEnumerator LootingShelves(Inventory inventory, PlayerController pl)
    {
        anim.Play("PressingE");
        pl.TurnMovement(false);
        pl.enabled = false;
        
        yield return new WaitForSeconds(2.5f);

        pl.TurnMovement(true);
        pl.enabled = true;
        GetComponent<SpriteRenderer>().color = Color.gray;
        inventory.AddItem(prefabUI);    // adding item
        ShowHint(false);
        Destroy(this);
    }
}
