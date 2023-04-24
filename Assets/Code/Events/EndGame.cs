using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public Transform dialogueParent;
    public GameObject dialoguePrefab;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
            ShowDialogue();
    }
    
    private void ShowDialogue()
    {
        dialogueParent.gameObject.SetActive(true);
        Instantiate(dialoguePrefab, dialogueParent.transform);
        Destroy(gameObject);
    }

    public void ChangeSceneToOutro()
    {
        SceneManager.LoadScene("Outro");
    }

    public void ReloadGame()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene("Game");
    }
}
