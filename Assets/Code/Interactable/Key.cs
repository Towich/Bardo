using System;
using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt { get; }
    public GameObject prefabUI;
    
    private Canvas canvasHint;
    public Animator anim;

    private void Start()
    {
        canvasHint = GetComponentInChildren<Canvas>();
        canvasHint.enabled = false;
    }

    public bool Interact(Interactor interactor)
    {
        Inventory inventory = interactor.gameObject.GetComponent<Inventory>();
        PlayerController pl = interactor.gameObject.GetComponent<PlayerController>();

        if (inventory != null)
        {
            Debug.Log("Added " + _prompt + "!");

            StartCoroutine(LootingKey(inventory, pl));
            
            return true;
        }

        return false;
    }

    public void ShowHint(bool toShow)
    {
        if(canvasHint != null)
            canvasHint.enabled = toShow;
    }
    
    private IEnumerator LootingKey(Inventory inventory, PlayerController pl)
    {
        anim.Play("PressingE");
        pl.TurnMovement(false);
        pl.enabled = false;
        
        yield return new WaitForSeconds(2.5f);

        pl.TurnMovement(true);
        pl.enabled = true;
        inventory.AddItem(prefabUI);    // adding item
        Destroy(gameObject);
    }
}
