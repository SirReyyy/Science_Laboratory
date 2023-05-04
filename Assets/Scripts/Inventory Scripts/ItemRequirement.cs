using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public struct ItemRequirement {

    public InventorySystem inventorySystem;
    public InventoryItemData itemData1;
    public InventoryItemData itemData2;
    public InventoryItemData itemData3;


    void Start() {
        inventorySystem = GameObject.Find("GameManager").GetComponent<InventorySystem>();
    } //-- Start() --

    public bool HasRequirement() {
        InventoryItem item1 = inventorySystem.Get(itemData1);
        InventoryItem item2 = inventorySystem.Get(itemData2);
        InventoryItem item3 = inventorySystem.Get(itemData3);

        if(item1 == null || item2 == null || item3 == null) {
            return false;
        }

        return true;
    } //-- HasRequirement() --
}


/*

Made by : Rey M. Oronos, Jr.
Project : Science Laboratory

*/