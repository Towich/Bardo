using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueNodeLastEvent : MonoBehaviour
{
    [SerializeField] private string text;
    [SerializeField] private string answer1;

    public GameObject nextDialoguePrefab;
    
    private PlayerController player;
    private GameObject dialogueUI;
    public Text textUI;
    public Text answer1UI;

    private GameManager gameManager;

    private void Start()
    {
        textUI.text = text;
        answer1UI.text = answer1;
        dialogueUI = transform.parent.gameObject;
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void CloseDialogue()
    {
        player.enabled = true;
        player.TurnMovement(true);
        Time.timeScale = 1;
        gameManager.StartOpenDialogueAfterEnemies(nextDialoguePrefab, 4f);
        Destroy(gameObject);
        dialogueUI.SetActive(false);
    }
}
