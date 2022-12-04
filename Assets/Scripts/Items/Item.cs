using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public enum ItemType
    {
        DodgeGadget,
        BaseItem,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.BaseItem: return ItemAssets.Instance.BaseItem;
            case ItemType.DodgeGadget: return ItemAssets.Instance.DodgeGadget;
        }
    }

    public bool IsStackable()
    {
        switch (itemType)
        {
            default:
            case ItemType.BaseItem: return true;
            case ItemType.DodgeGadget: return false;
        }
    }
}