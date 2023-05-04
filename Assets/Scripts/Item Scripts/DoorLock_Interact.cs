using UnityEngine;

public class DoorLock_Interact : MonoBehaviour, IInteractable {
    
    public InventorySystem inventorySystem;
    public InventoryItemData itemReq1;
    public InventoryItemData itemReq2;
    public InventoryItemData itemReq3;

    public bool isLaboratory;
    bool labClose;
    bool storageClose;

    void Start() {
        inventorySystem = GameObject.Find("GameManager").GetComponent<InventorySystem>();
    } //-- Start() --

    public void Interact() {
        if(isLaboratory) {      // Laboratory Room
            if(HasRequirement()) {
                if(labClose) {
                    // Open animation

                    Debug.Log("open");
                    labClose = false;
                } else {
                    // Close animation

                    Debug.Log("close");
                    labClose = true;
                }
            } else {
                // missing notif
                Debug.Log("missing");
            }



        } else {
            // Storage Room
            if(storageClose) {
                // Open animation

                Debug.Log("false");
                storageClose = false;
            } else {
                // Close animation

                Debug.Log("true");
                storageClose = true;
            }
        }

    } //-- Interact() --

    public bool HasRequirement() {
        InventoryItem labItem1 = inventorySystem.Get(itemReq1);
        InventoryItem labItem2 = inventorySystem.Get(itemReq2);
        InventoryItem labItem3 = inventorySystem.Get(itemReq3);

        if(labItem1 == null || labItem2 == null || labItem3 == null) {
            return false;
        }

        return true;
    } //-- HasRequirement() --
}

/*

Made by : Rey M. Oronos, Jr.
Project : Science Laboratory

*/