using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    
    public string InteractionPrompt { get; }
    public GameObject logicGame;
    
    private Canvas canvasHint;
    private PlayerController playerController;

    private void Start()
    {
        canvasHint = GetComponentInChildren<Canvas>();
        canvasHint.enabled = false;
    }

    public bool Interact(Interactor interactor)
    {
        playerController = interactor.GetComponent<PlayerController>();
        Debug.Log("Open terminal");
        //ShowHint(false);
        logicGame.SetActive(true);
        
        playerController.enabled = false;
        return true;
    }

    public void CloseLogicGame()
    {
        logicGame.SetActive(false);
        playerController.enabled = true;
    }

    public void ShowHint(bool toShow) { canvasHint.enabled = toShow; }
}
