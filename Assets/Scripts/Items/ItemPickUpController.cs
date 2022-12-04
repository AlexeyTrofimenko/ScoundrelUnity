using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemPickUpController : MonoBehaviour
{
    private bool showItemPickUpMenu = false;
    public string itemName = "[ Default item ]";
    public TMP_Text itemNameContainer;

    private AudioSource audioSource;
    public float volume = 1.0f;
    public AudioClip pickUpSound;

    private ItemWorld itemWorld;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = Camera.main.GetComponent<AudioSource>();
        itemNameContainer.text = itemName;

        itemWorld = GetComponent<ItemWorld>();

        if (itemName.Contains("Dodge"))
        {
            itemWorld.SetItem(new Item { itemType = Item.ItemType.DodgeGadget, amount = 1 });
        }
        else
        {
            itemWorld.SetItem(new Item { itemType = Item.ItemType.BaseItem, amount = 1 });
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && showItemPickUpMenu)
        {
            PickUpItem();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            showItemPickUpMenu = true;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            showItemPickUpMenu = false;
        }
    }

    private void OnGUI()
    {
        if (showItemPickUpMenu)
        {
            itemNameContainer.alpha = 100;
        }
        else
        {
            itemNameContainer.alpha = 0;
        }
    }

    void PickUpItem()
    {
        PlayPickUpSound();
        Inventory inventory = Player.Instance.GetInventory();
        Item item = itemWorld.GetItem();
        inventory.AddItem(item);
        itemWorld.DestroySelf();
    }

    void PlayPickUpSound()
    {
        audioSource.PlayOneShot(pickUpSound, volume);
    }
}