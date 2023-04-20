using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicElem : MonoBehaviour
{
    public string typeOfElement;
    public bool outputSignal;
    
    public LogicElem[] inputElements;
    public LogicElem[] outputElements;
    public LogicWire[] outputWires;

    public Sprite spriteAND;
    public Sprite spriteOR;

    public void SetSignal(bool newSignal)
    {
        outputSignal = newSignal;
        foreach (var wire in outputWires) { wire.SetEnabled(newSignal); }
    }

    public void ChangeTypeElem(string newType)
    {
        typeOfElement = newType;
        switch (newType)
        {
            case "AND":
                gameObject.GetComponent<Image>().sprite = spriteAND;
                break;
            case "OR":
                gameObject.GetComponent<Image>().sprite = spriteOR;
                break;
        }
    }

}
