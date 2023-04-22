using System.Collections;
using UnityEngine;

public class Lift : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    
    public string InteractionPrompt => _prompt;
    
    private Canvas canvasHint;
    public Animator animPressE;
    public Animator animOpenLift;

    private void Start()
    {
        canvasHint = GetComponentInChildren<Canvas>();
        canvasHint.enabled = false;
    }

    public bool Interact(Interactor interactor)
    {
        Inventory inventory = interactor.gameObject.GetComponent<Inventory>();
        PlayerController pl = interactor.gameObject.GetComponent<PlayerController>();

        if (_prompt.Equals("opened") || (inventory != null && inventory.HasItem(_prompt)))
        {
            Debug.Log("Opening lift!");
            StartCoroutine(OpeningLift(inventory, pl));
            _prompt = "opened";
            return true;
        }
        
        Debug.Log("NO BATTERY: " + _prompt);
        return false;
    }

    private IEnumerator OpeningLift(Inventory inventory, PlayerController pl)
    {
        animPressE.Play("PressingE");

        pl.TurnMovement(false);
        pl.enabled = false;
        
        yield return new WaitForSeconds(2f);

        animOpenLift.Play("LiftOpen");
        
        yield return new WaitForSeconds(0.5f);
        
        pl.TurnMovement(true);
        pl.enabled = true;
        inventory.RemoveItem(_prompt);  // removing item "PowerCell"
        ShowHint(false);
        Destroy(this);
    }

    public void ShowHint(bool toShow)
    {
        canvasHint.enabled = toShow;
    }
}
