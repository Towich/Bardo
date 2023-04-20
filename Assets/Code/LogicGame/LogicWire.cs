using System;
using UnityEngine;

public class LogicWire : MonoBehaviour
{
    public Sprite spriteEnabled;
    public Sprite spriteDisabled;
    public bool wireEnabled;

    private SpriteRenderer sr;
    private void Start()
    {
        wireEnabled = false;
        sr = GetComponent<SpriteRenderer>();
    }

    public void SetEnabled(bool newEnabled)
    {
        wireEnabled = newEnabled;

        sr.sprite = newEnabled ? spriteEnabled : spriteDisabled;
    }
}
