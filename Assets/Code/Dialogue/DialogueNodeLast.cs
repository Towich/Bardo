using System;
using UnityEngine;
using UnityEngine.UI;

public class DialogueNodeLast : MonoBehaviour
{
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

    public void CloseDialogue()
    {
        player.enabled = true;
        player.TurnMovement(true);
        dialogueUI.SetActive(false);
        Destroy(gameObject);
    }
}
