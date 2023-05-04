using UnityEngine;
using UnityEngine.UI;

public class PickUp_Interact : MonoBehaviour, IInteractable {
    
    public InventoryItemData referenceItem;
    public InventorySystem inventorySystem;
    public UIManager uiManager;


    private int itemId;
    private string itemName;


    void Start() {
        inventorySystem = GameObject.Find("GameManager").GetComponent<InventorySystem>();
        uiManager = GameObject.Find("GameManager").GetComponent<UIManager>();
    } //-- Start() --

    public void Interact() {
        inventorySystem.Add(referenceItem);
        Destroy(gameObject);

        itemId = referenceItem.id;
        // itemName = referenceItem.displayName;

        // uiManager.PickUpNotif(itemName);
        uiManager.UpdateInventoryIcon(itemId - 1);

    } //-- Interact() --
}


/*

Made by : Rey M. Oronos, Jr.
Project : Science Laboratory

*/