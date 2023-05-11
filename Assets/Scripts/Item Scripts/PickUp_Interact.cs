using UnityEngine;
using UnityEngine.UI;

public class PickUp_Interact : MonoBehaviour, IInteractable {
    
    public InventoryItemData referenceItem;
    public InventorySystem inventorySystem;
    public UIManager uiManager;

    public TaskManager _taskManager;
    public TaskData _taskData;
    public ChattyManager chattyManager;


    private int itemId;
    private string itemName;


    void Start() {
        inventorySystem = GameObject.Find("GameManager").GetComponent<InventorySystem>();
        uiManager = GameObject.Find("GameManager").GetComponent<UIManager>();
        _taskManager = GameObject.Find("GameManager").GetComponent<TaskManager>();
        chattyManager = GameObject.Find("GameManager").GetComponent<ChattyManager>();
    } //-- Start() --

    public void Interact() {
        inventorySystem.Add(referenceItem);
        _taskData.isFinished = true;

        if(_taskData.mainId == 1) {
            _taskManager.MainTask1Count++;
        } else {
            _taskManager.MainTask2Count++;
        }
        
        Destroy(gameObject);
        
        itemId = referenceItem.id;
        chattyManager.ComplimentMessages(itemId);
        uiManager.UpdateInventoryIcon(itemId - 1);

    } //-- Interact() --
}


/*

Made by : Rey M. Oronos, Jr.
Project : Science Laboratory

*/