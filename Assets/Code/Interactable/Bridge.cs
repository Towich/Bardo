using System.Collections;
using UnityEngine;

public class Bridge : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;

    private Canvas canvasHint;
    
    public Animator animatorBridge;
    public Animator animatorHint;

    private void Start() {
        animatorBridge = GetComponent<Animator>();
        canvasHint = GetComponentInChildren<Canvas>();
        canvasHint.enabled = false;
    }

    public bool Interact(Interactor interactor) {
        Inventory inv = interactor.GetComponent<Inventory>();
        PlayerController pl = interactor.GetComponent<PlayerController>();

        if (inv) {
            if (inv.HasItem("Универсальный строительный инструмент"))
            {
                Debug.Log("Building the bridge!");

                StartCoroutine(BuildingBridge(pl));
                
                // ShowHint(false);
                // canvasHint = null;
                return true;
            }
            else
            {
                // we don't have "Универсальный строительный инструмент"
                return false;
            }
        }

        return false;
    }

    public void ShowHint(bool toShow) {
        if (canvasHint != null)
            canvasHint.enabled = toShow;
    }
    
    private IEnumerator BuildingBridge(PlayerController pl)
    {
        animatorBridge.Play("BridgeBuild");
        animatorHint.Play("PressingE");
        
        pl.TurnMovement(false);
        pl.enabled = false;
        
        yield return new WaitForSeconds(2.5f);

        pl.TurnMovement(true);
        pl.enabled = true;
        ShowHint(false);
        canvasHint = null;
        Destroy(this);
    }
}
