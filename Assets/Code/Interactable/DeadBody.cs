using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBody : MonoBehaviour, IInteractable
{
    public string InteractionPrompt { get; }
    
    private Canvas canvasHint;
    
    private void Start()
    {
        canvasHint = GetComponentInChildren<Canvas>();
        canvasHint.enabled = false;
    }
    public bool Interact(Interactor interactor)
    {
        //Debug.Log("Looting the dead body!");

        PlayerController pc = interactor.gameObject.GetComponent<PlayerController>();
        pc.TakeDecreaseStability(10);
        
        GetComponent<SpriteRenderer>().color = Color.gray;
        ShowHint(false);
        Destroy(this);
        return true;
    }

    public void ShowHint(bool toShow)
    {
        canvasHint.enabled = toShow;
    }
}
