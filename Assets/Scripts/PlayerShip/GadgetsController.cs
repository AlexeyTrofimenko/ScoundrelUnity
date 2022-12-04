using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GadgetsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Inventory inventory = Player.Instance.GetInventory();
            List<Item> itemList = inventory.GetItemList();
            foreach (Item item in itemList)
            {
                if (item.itemType == Item.ItemType.DodgeGadget)
                {
                    DodgeGadgetActivate();
                    break;
                }
            }
        }
    }

    void DodgeGadgetActivate()
    {
        ShipStats.inDodge = true;
    }
}