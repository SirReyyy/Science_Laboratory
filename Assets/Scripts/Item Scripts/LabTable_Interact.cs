using UnityEngine;

public class LabTable_Interact : MonoBehaviour, IInteractable {

    public InventorySystem inventorySystem;
    public InventoryItemData itemReq1;
    public InventoryItemData itemReq2;

    void Start() {
        inventorySystem = GameObject.Find("GameManager").GetComponent<InventorySystem>();
    } //-- Start() --

    public void Interact() {
        if(HasRequirement()) {
            // Lab Experiment
            Debug.Log("okay");
        } else {
            // Missing notification
            Debug.Log("missing");
        }
    } //-- Interact() --

    public bool HasRequirement() {
        InventoryItem expItem1 = inventorySystem.Get(itemReq1);
        InventoryItem expItem2 = inventorySystem.Get(itemReq2);

        if(expItem1 == null || expItem2 == null) {
            return false;
        }

        return true;
    } //-- HasRequirement() --
}


/*

Made by : Rey M. Oronos, Jr.
Project : Science Laboratory

*/