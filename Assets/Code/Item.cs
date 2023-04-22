using System;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private string nameItem;

    private Text textUI;
    private Image imageUI;
    
    private void Start()
    {
        textUI = GetComponentInChildren<Text>();
        imageUI = GetComponentInChildren<Image>();
    }

    public string Name => nameItem;
}
