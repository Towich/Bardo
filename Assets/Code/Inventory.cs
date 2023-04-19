using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<String> items;

    private void Start()
    {
        items = new List<String>(5);
    }

    public void AddItem(string itemToAdd)
    {
        items.Add(itemToAdd);
    }

    public bool HasItem(string itemToFind)
    {
        foreach (var i in items)
        {
            if (itemToFind == i)
            {
                return true;
            }
        }

        return false;
    }
}
