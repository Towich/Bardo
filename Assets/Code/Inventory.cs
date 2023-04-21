using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryUI;

    public List<Item> items;

    private void Start()
    {
        items = new List<Item>(5);
    }

    public void AddItem(GameObject prefabItemUI)
    {
        GameObject newItem = Instantiate(prefabItemUI, inventoryUI.transform);
        newItem.transform.localPosition = Vector3.zero;
        items.Add(newItem.GetComponent<Item>());
        UpdateItemList();
    }

    public void RemoveItem(string itemToRemove)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (itemToRemove == items[i].Name)
            {
                Destroy(items[i].gameObject);
                items.Remove(items[i]);
            }
        }
        UpdateItemList();
    }

    public bool HasItem(string itemToFind)
    {
        foreach (var i in items)
        {
            if (itemToFind == i.Name)
            {
                return true;
            }
        }

        return false;
    }

    public void UpdateItemList()
    {
        for (int i = 0; i < items.Count; i++)
        {
            var pos = items[i].transform.localPosition;
            items[i].transform.localPosition = new Vector3(pos.x, -70 * i, pos.z);
        }
    }

    public bool CraftBuildTool(GameObject prefabBuildTool)
    {
        if (HasItem("Ядро жесткого света") && HasItem("Универсальная преобразуемая основа"))
        {
            RemoveItem("Ядро жесткого света");
            RemoveItem("Универсальная преобразуемая основа");
            AddItem(prefabBuildTool);
            return true;
        }

        return false;
    }
}
