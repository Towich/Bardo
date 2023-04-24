using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] public string _prompt;
    
    public string InteractionPrompt => _prompt;
    
    private Canvas canvasHint;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        canvasHint = GetComponentInChildren<Canvas>();
        canvasHint.enabled = false;
    }
    
    public bool Interact(Interactor interactor)
    {
        if (InteractionPrompt.Equals("Closed"))
            return false;
        
        Debug.Log("Opening door!");
        anim.Play("OpenDoor");
        ShowHint(false);
        canvasHint = null;
        return true;
    }

    public void ShowHint(bool toShow)
    {
        if(canvasHint != null)
            canvasHint.enabled = toShow;
    }
    
}
