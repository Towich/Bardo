using System;
using UnityEngine;
using UnityEngine.UI;

public class LogicTree : MonoBehaviour
{
    public LogicElem[] rootNodes;
    public LogicElem[] logicElems;

    public LogicElem finalElem;
    
    public void UpdateAllTree()
    {
        foreach (var rootNode in rootNodes)
        {
            UpdateSignal(rootNode);
        }
        if (finalElem.outputSignal)
        {
            finalElem.outputElements[0].GetComponent<Image>().color = Color.white;
            WinGame();
        }
    }

    public void UpdateSignal(LogicElem node)
    {
        bool newSignal;
        switch (node.typeOfElement)
        {
            case "AND":
                newSignal = true;
                
                foreach (var elem in node.inputElements)
                {
                    newSignal = newSignal && elem.outputSignal;
                }

                node.SetSignal(newSignal);
                break;
            
            case "OR":
                newSignal = false;
                
                foreach (var elem in node.inputElements)
                {
                    newSignal = newSignal || elem.outputSignal;
                }

                node.SetSignal(newSignal);
                break;
            
            case "NOT":
                node.SetSignal(!node.inputElements[0].outputSignal);
                break;
            
            case "FINAL":
                node.SetSignal(node.inputElements[0].outputSignal);
                break;
            
            case "STATIC":
                node.SetSignal(node.outputSignal);
                break;
        }

        foreach (var elem in node.outputElements)
        {
            UpdateSignal(elem);
        }
    }

    private void WinGame()
    {
        foreach (var elem in logicElems)
        {
            elem.GetComponent<Button>().interactable = false;
        }
    }
}
