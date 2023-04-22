using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    private Text text;

    private void Start()
    {
        text = GetComponentInChildren<Text>();
    }

    public void MouseOn()
    {
        text.enabled = true;
    }

    public void MouseOff()
    {
        text.enabled = false;
    }
}
