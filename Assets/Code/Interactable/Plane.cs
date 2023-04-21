using UnityEngine;

public class Plane : MonoBehaviour, IInteractable
{
    public string InteractionPrompt { get; }
    
    public GameObject planeUI;
    public GameObject mapUI;
    public GameObject craftUI;
    
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
        
        playerController.enabled = false;
        planeUI.SetActive(true);
        
        return true;
    }

    public void ShowHint(bool toShow)
    {
        canvasHint.enabled = toShow;
    }

    public void ClosePlaneUI()
    {
        planeUI.SetActive(false);
        playerController.enabled = true;
    }

    public void OpenMapUI()
    {
        craftUI.SetActive(false);
        mapUI.SetActive(true);
    }
    
    public void OpenCraftUI()
    {
        mapUI.SetActive(false);
        craftUI.SetActive(true);
    }
}
