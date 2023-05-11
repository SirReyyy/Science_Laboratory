using UnityEngine;

public class LabTable_Interact : MonoBehaviour, IInteractable {

    public InventorySystem inventorySystem;
    public InventoryItemData itemReq1;
    public InventoryItemData itemReq2;

    public TaskManager _taskManager;
    public TaskData _taskData;

    public ChattyManager chattyManager;


    bool finishedExperiment = false;
    public bool isLabTable;

    void Start() {
        inventorySystem = GameObject.Find("GameManager").GetComponent<InventorySystem>();
        _taskManager = GameObject.Find("GameManager").GetComponent<TaskManager>();
        chattyManager = GameObject.Find("GameManager").GetComponent<ChattyManager>();
    } //-- Start() --

    public void Interact() {
        if(!isLabTable) {
            chattyManager.WarningMessages(2);
            return;
        }

        if(!finishedExperiment) {
            if(HasRequirement()) {
            
                _taskData.isFinished = true;

                if(_taskData.mainId == 1) {
                    _taskManager.MainTask1Count++;
                } else {
                    _taskManager.MainTask2Count++;
                }

                finishedExperiment = true;

                chattyManager.ComplimentMessages(7);

            } else {
                chattyManager.WarningMessages(1);
            }
        } else {
            chattyManager.WarningMessages(3);
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