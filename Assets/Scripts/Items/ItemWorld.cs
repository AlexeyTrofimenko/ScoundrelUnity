using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    private Item item;

    private SpriteRenderer spriteRenderer;
    private TextMeshPro textMeshPro;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        textMeshPro = GetComponentInChildren<TextMeshPro>();
    }


    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
        if (item.amount > 1)
        {
            textMeshPro.SetText(item.amount.ToString());
        }
        else
        {
            textMeshPro.SetText("");
        }
    }

    public Item GetItem()
    {
        return item;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}