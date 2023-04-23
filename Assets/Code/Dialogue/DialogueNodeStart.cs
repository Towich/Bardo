using System;
using UnityEngine;
using UnityEngine.UI;

public class DialogueNodeStart : MonoBehaviour
{
    [SerializeField] private GameObject nextDialogue;
    
    [SerializeField] private string text;
    [SerializeField] private string answer1;

    private PlayerController player;
    private GameObject dialogueUI;
    public Text textUI;
    public Text answer1UI;
    

    private void Start()
    {
        textUI.text = text;
        answer1UI.text = answer1;
        dialogueUI = transform.parent.gameObject;
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    
    public void NextDialogue()
    {
        Instantiate(nextDialogue, transform.parent);
        Destroy(gameObject);
    }
}
