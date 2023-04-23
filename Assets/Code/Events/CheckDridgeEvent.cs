using System;
using UnityEngine;

public class CheckDridgeEvent : MonoBehaviour
{
    public GameObject dialoguePrefab;

    public Transform dialogueParent;
    public PlayerController player;
    public GameObject terminal;
    private Canvas terminalCanvas;

    private void Start()
    {
        terminalCanvas = terminal.GetComponentInChildren<Canvas>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            player.TurnMovement(false);
            player.enabled = false;

            terminal.layer = 7;
            terminal.GetComponent<Terminal>().enabled = true;
            terminalCanvas.enabled = true;
            
            dialogueParent.gameObject.SetActive(true);
            Instantiate(dialoguePrefab, dialogueParent);
            Destroy(gameObject);
        }
    }
}