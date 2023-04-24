using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    public LeverManager leverManager;
    public bool leverEnabled;

    private SpriteRenderer spriteRenderer;
    public Sprite spriteOn;
    public Sprite spriteOff;
    
    
    [SerializeField] private string _prompt;
    
    public string InteractionPrompt => _prompt;
    
    private Canvas canvasHint;

    private void Start()
    {
        leverEnabled = false;
        canvasHint = GetComponentInChildren<Canvas>();
        canvasHint.enabled = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    public bool Interact(Interactor interactor)
    {
        Debug.Log("Turning lever!");

        TurnLever();
        
        ShowHint(false);
        return true;
    }
    
    public void ShowHint(bool toShow)
    {
        if(canvasHint != null)
            canvasHint.enabled = toShow;
    }

    private void TurnLever()
    {
        leverEnabled = !leverEnabled;
        spriteRenderer.sprite = leverEnabled ? spriteOn : spriteOff;
        leverManager.UpdateGame();
    }
}
