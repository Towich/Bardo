using System;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private string nameItem;
    [SerializeField] private Sprite spriteItem;

    private Text textUI;
    private Image imageUI;
    
    private void Start()
    {
        textUI = GetComponentInChildren<Text>();
        imageUI = GetComponentInChildren<Image>();

        textUI.text = nameItem;
        imageUI.sprite = spriteItem;
    }

    public string Name => nameItem;
}
