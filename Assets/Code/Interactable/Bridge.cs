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

        if (inv) {
            if (inv.HasItem("Универсальный строительный инструмент"))
            {
                Debug.Log("Building the bridge!");
                animatorBridge.Play("BuildBridge");
                animatorHint.Play("PressingE");
                ShowHint(false);
                canvasHint = null;
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
}
