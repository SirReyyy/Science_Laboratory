using UnityEngine;

public class LabTable_Interact : MonoBehaviour, IInteractable {

    public InventorySystem inventorySystem;
    public InventoryItemData itemReq1;
    public InventoryItemData itemReq2;

    public TaskManager _taskManager;
    public TaskData _taskData;

    bool finishedExperiment = false;

    void Start() {
        inventorySystem = GameObject.Find("GameManager").GetComponent<InventorySystem>();
        _taskManager = GameObject.Find("GameManager").GetComponent<TaskManager>();
    } //-- Start() --

    public void Interact() {
        if(!finishedExperiment) {
            if(HasRequirement()) {
            
                _taskData.isFinished = true;

                if(_taskData.mainId == 1) {
                    _taskManager.MainTask1Count++;
                } else {
                    _taskManager.MainTask2Count++;
                }

                finishedExperiment = true;

            } else {
                // Missing notification
                Debug.Log("missing components");
            }
        } else {
            // Already done pop-up
            Debug.Log("done experiment");
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