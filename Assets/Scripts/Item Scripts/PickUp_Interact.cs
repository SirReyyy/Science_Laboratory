using UnityEngine;

public class PickUp_Interact : MonoBehaviour, IInteractable {
    
    public InventoryItemData referenceItem;
    public InventorySystem inventorySystem;
    // public GameObject inventory;

    void Start() {
        inventorySystem = GameObject.Find("InventorySystem").GetComponent<InventorySystem>();
        // inventorySystem = InventorySystem.Find()
    } //-- Start() --

    public void Interact() {
       inventorySystem.Add(referenceItem);
       Destroy(gameObject);
    } //-- Interact() --
}


/*

Made by : Rey M. Oronos, Jr.
Project : Science Laboratory

*/