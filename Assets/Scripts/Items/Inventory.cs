using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Inventory
{
    private List<Item> itemList;

    public event EventHandler OnItemListChanged;

    public Inventory()
    {
        itemList = new List<Item>();
    }

    public void AddItem(Item item)
    {
        if (item.IsStackable())
        {
            bool alreadyInInventory = false;
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    alreadyInInventory = true;
                    inventoryItem.amount += item.amount;
                }
            }

            if (!alreadyInInventory)
            {
                itemList.Add(item);
            }
        }
        else
        {
            itemList.Add(item);
        }


        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
}