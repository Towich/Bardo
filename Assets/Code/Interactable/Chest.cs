using System;
using System.Collections;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    
    public string InteractionPrompt => _prompt;
    public GameObject prefabUI;

    private Canvas canvasHint;
    private Animator anim;

    private void Start()
    {
        canvasHint = GetComponentInChildren<Canvas>();
        anim = GetComponentInChildren<Animator>();
        canvasHint.enabled = false;
    }

    public bool Interact(Interactor interactor)
    {
        Inventory inventory = interactor.gameObject.GetComponent<Inventory>();
        PlayerController pl = interactor.gameObject.GetComponent<PlayerController>();

        if (inventory != null && inventory.HasItem(_prompt))
        {
            Debug.Log("Opening chest!");
            StartCoroutine(LootingChest(inventory, pl));
            return true;
        }
        
        Debug.Log("NO KEY: " + _prompt);
        return false;
    }

    private IEnumerator LootingChest(Inventory inventory, PlayerController pl)
    {
        anim.Play("PressingE");
        pl.enabled = false;
        
        yield return new WaitForSeconds(2.5f);
        
        pl.enabled = true;
        GetComponent<SpriteRenderer>().color = Color.green;
        inventory.AddItem(prefabUI);    // adding item "RandomItem"
        inventory.RemoveItem(_prompt);  // removing item "Ключ-карта"
        ShowHint(false);
        Destroy(this);
    }

    public void ShowHint(bool toShow)
    {
        canvasHint.enabled = toShow;
    }
}
