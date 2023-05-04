using UnityEngine;

public class InventoryItem {
    
    public InventoryItemData data { get; private set; }
    public int stackSize {get; private set; }

    public InventoryItem(InventoryItemData source) {
        data = source;
        AddToStack();
    } //-- InventoryItem

    public void AddToStack() {
        stackSize++;
    } //-- AddToStack

    public void RemoveFromStack() {
        stackSize--;
    } //-- RemoveFromStack
}


/*

Made by : Rey M. Oronos, Jr.
Project : Science Laboratory

*/