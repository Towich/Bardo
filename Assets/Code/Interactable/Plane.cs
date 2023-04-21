using UnityEngine;
using UnityEngine.UI;

public class Plane : MonoBehaviour, IInteractable
{
    public string InteractionPrompt { get; }

    public GameObject prefabBuildTool;
    
    public Inventory inventory;
    public GameObject planeUI;
    public GameObject mapUI;
    public GameObject craftUI;
    public Text outputCraftText;
    
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
        outputCraftText.text = "";
        mapUI.SetActive(false);
        craftUI.SetActive(true);
    }

    public void Craft()
    {
        bool crafted = inventory.CraftBuildTool(prefabBuildTool);
        if (crafted)
        {
            outputCraftText.text = "Удачно!";
            outputCraftText.color = Color.green;
        }
        else
        {
            outputCraftText.text = "Не удачно!";
            outputCraftText.color = Color.red;
        }
    }
}
