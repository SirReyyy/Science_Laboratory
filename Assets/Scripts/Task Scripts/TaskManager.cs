using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour {

    public Canvas PlayerHUD;
    public InventorySystem inventorySystem;
    Transform mainTask, subTask;
    bool mainActive = false, subActive = false;

    void Start() {
        mainTask = PlayerHUD.transform.Find("Task");
        subTask = PlayerHUD.transform.Find("Task").transform.GetChild(1);
    } //-- Start() --

    
    public void ShowTaskList() {
        if(!mainActive) {
            mainTask.gameObject.SetActive(true);
            mainActive = true;
        } else {
            if(!subActive) {
                subTask.gameObject.SetActive(true);
                subActive = true;
            } else {
                mainTask.gameObject.SetActive(false);
                subTask.gameObject.SetActive(false);
                mainActive = false;
                subActive = false;
            }
        }
    } //-- ShowTaskList() --
}


/*

Made by : Rey M. Oronos, Jr.
Project : Science Laboratory

*/