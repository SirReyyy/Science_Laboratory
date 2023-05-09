using UnityEngine;
using UnityEngine.Animations;

public class DoorLock_Interact : MonoBehaviour, IInteractable {
    
    public InventorySystem inventorySystem;
    public InventoryItemData itemReq1;
    public InventoryItemData itemReq2;
    public InventoryItemData itemReq3;

    public bool isLaboratory;
    bool labClose = true;
    bool storageClose = true;

    public Animator storageDoorAnimator;
    public Animator labDoorAnimator;
    

    void Start() {
        inventorySystem = GameObject.Find("GameManager").GetComponent<InventorySystem>();
        storageDoorAnimator = GameObject.Find("Door (Storage)").GetComponent<Animator>();
        labDoorAnimator = GameObject.Find("Door (Lab)").GetComponent<Animator>();
    } //-- Start() --

    public void Interact() {
        if(isLaboratory) {      // Laboratory Room
            if(HasRequirement()) {
                if(labClose) {
                    labDoorAnimator.SetBool("isClose", false);
                    labClose = false;
                } else {
                    labDoorAnimator.SetBool("isClose", true);
                    labClose = true;
                }
            } else {
                // missing notif
                Debug.Log("missing");
            }
        } else {
            // Storage Room
            if(storageClose) {
                storageDoorAnimator.SetBool("isClose", false);
                storageClose = false;
            } else {
                storageDoorAnimator.SetBool("isClose", true);
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