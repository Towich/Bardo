using System;
using UnityEngine;

public class LogicButton : MonoBehaviour
{
    [SerializeField] private LogicTree tree;
    private LogicElem elem;

    private void Start()
    {
        elem = GetComponent<LogicElem>();
    }

    public void OnButtonPressed()
    {
        Debug.Log("Presses!");
        string typeOfElem = elem.typeOfElement;

        switch (typeOfElem)
        {
            case "AND":
                elem.ChangeTypeElem("OR");
                break;
            case "OR":
                elem.ChangeTypeElem("AND");
                break;
        }
        tree.UpdateAllTree();
    }

    private void OnMouseDown()
    {
        Debug.Log("Presses!");
        string typeOfElem = elem.typeOfElement;

        switch (typeOfElem)
        {
            case "AND":
                elem.ChangeTypeElem("OR");
                break;
            case "OR":
                elem.ChangeTypeElem("AND");
                break;
        }
        tree.UpdateAllTree();
    }
}
