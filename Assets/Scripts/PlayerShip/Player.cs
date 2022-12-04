using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    private Inventory inventory;

    [SerializeField] private UI_Inventory uiInventory;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Awake()
    {
        Instance = this;
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
    }

    public Inventory GetInventory()
    {
        return inventory;
    }
}