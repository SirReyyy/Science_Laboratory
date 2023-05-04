using UnityEngine;
using System.Collections.Generic;

public class InventorySystem : MonoBehaviour {
    
    private Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;
    public List<InventoryItem> inventory {get; private set; }

    private void Awake() {
        inventory = new List<InventoryItem>();
        m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
    } //-- Awake

    public InventoryItem Get(InventoryItemData referenceData) {
        if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value)) {
            return value;
        }
        return null;
    } //-- InventoryItem Get
    
    public void Add(InventoryItemData referenceData) {
        if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value)) {
            value.AddToStack();
        } else {
            InventoryItem newItem = new InventoryItem(referenceData);
            inventory.Add(newItem);
            m_itemDictionary.Add(referenceData, newItem);
        }
    } //-- Add

    public void Remove(InventoryItemData referenceData) {
        if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value)) {
            value.RemoveFromStack();

            if(value.stackSize == 0) {
                inventory.Remove(value);
                m_itemDictionary.Remove(referenceData);
            }
        }
    } //-- Remove
}


/*

Made by : Rey M. Oronos, Jr.
Project : Science Laboratory

*/