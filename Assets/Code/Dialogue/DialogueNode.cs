using System;
using UnityEngine;
using UnityEngine.UI;

public class DialogueNode : MonoBehaviour
{
    [SerializeField] private GameObject nextDialogue1;
    [SerializeField] private GameObject nextDialogue2;
    
    [SerializeField] private string text;
    [SerializeField] private string answer1;
    [SerializeField] private string answer2;

    public Text textUI;
    public Text answer1UI;
    public Text answer2UI;
    
    private void Start()
    {
        textUI.text = text;
        answer1UI.text = answer1;
        answer2UI.text = answer2;
    }

    public void NextDialogue1()
    {
        Instantiate(nextDialogue1, transform.parent);
        Destroy(gameObject);
    }
    public void NextDialogue2()
    {
        Instantiate(nextDialogue2, transform.parent);
        Destroy(gameObject);
    }
}
