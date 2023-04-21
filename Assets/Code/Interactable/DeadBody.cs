using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBody : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject prefabUI;
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
        //Debug.Log("Looting the dead body!");
        
        Inventory inventory = interactor.gameObject.GetComponent<Inventory>();
        PlayerController pl = interactor.gameObject.GetComponent<PlayerController>();

        StartCoroutine(LootingBody(inventory, pl));

        return true;
    }

    public void ShowHint(bool toShow)
    {
        canvasHint.enabled = toShow;
    }
    
    private IEnumerator LootingBody(Inventory inventory, PlayerController pl)
    {
        anim.Play("PressingE");
        pl.TurnMovement(false);
        pl.enabled = false;
        
        yield return new WaitForSeconds(2.5f);

        pl.TurnMovement(true);
        pl.enabled = true;
        pl.TakeDecreaseStability(10);
        GetComponent<SpriteRenderer>().color = Color.gray;
        inventory.AddItem(prefabUI);    // adding item
        ShowHint(false);
        Destroy(this);
    }
}
