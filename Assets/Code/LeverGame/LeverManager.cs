using UnityEngine;

public class LeverManager : MonoBehaviour
{
    public Lever[] levers;
    
    public Transform dialogueParent;
    public GameObject dialoguePrefab;

    public Door doorToOpen;

    public void UpdateGame()
    {
        if (CheckWin())
        {
            Debug.Log("WIN!");
            foreach (var l in levers)
            {
                Destroy(l);
            }
            
            ShowDialogue();

            doorToOpen._prompt = "";
        }
    }

    private bool CheckWin()
    {
        bool won = true;

        for (int i = 0; i < 4; i++)
        {
            won = won && levers[i].leverEnabled;
        }

        for (int i = 4; i < 7; i++)
        {
            won = won && !levers[i].leverEnabled;
        }

        return won;
    }

    private void ShowDialogue()
    {
        dialogueParent.gameObject.SetActive(true);
        Instantiate(dialoguePrefab, dialogueParent.transform);
    }
}
