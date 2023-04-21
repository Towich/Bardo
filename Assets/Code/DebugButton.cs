using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugButton : MonoBehaviour
{
    public GameObject canvas;
    public bool showing;

    private void Start()
    {
        showing = false;
    }

    public void TurnCanvas()
    {
        showing = !showing;
        canvas.SetActive(showing);
    }
}
