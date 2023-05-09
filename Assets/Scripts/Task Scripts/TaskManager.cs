using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TaskManager : MonoBehaviour {

    private Dictionary<TaskData, Task> m_taskDictionary;
    public List<Task> task {get; private set;}

    public Canvas PlayerHUD;
    public InventorySystem inventorySystem;
    Transform mainTask, subTask;
    bool mainActive = false, subActive = false;


    void Awake() {
        task = new List<Task>();
        m_taskDictionary = new Dictionary<TaskData, Task>();
    } //-- Awake() --

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