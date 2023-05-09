using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TaskUI : MonoBehaviour {

    public TaskManager _taskManager;
    // UI
    public Canvas PlayerHUD;
    Transform mainTaskContainer, subTaskContainer, subTaskList;
    Text subTaskDetails;
    
    bool mainActive = false, subActive = false;


    void Start() {
        _taskManager = GameObject.Find("GameManager").GetComponent<TaskManager>();

        mainTaskContainer = PlayerHUD.transform.Find("Task");
        subTaskContainer = PlayerHUD.transform.Find("Task").transform.GetChild(1);
        subTaskList = subTaskContainer.transform.GetChild(1);

        mainTaskContainer.gameObject.SetActive(true);
        subTaskContainer.gameObject.SetActive(true);
        mainActive = true;
        subActive = true;

    } //-- Start() --

    public void UpdateTaskListUI(TaskData[] taskData) {
        foreach(TaskData td in taskData) {
            if(td.mainId == 1 && td.isActive) {
                subTaskDetails = subTaskList.GetChild(td.subId - 1).GetComponent<Text>();
                subTaskDetails.text = td.taskDetails;

                if(td.isActive && !td.isFinished){
                    subTaskDetails.color = Color.white;
                } else if(td.isActive && td.isFinished) {
                    subTaskDetails.color = Color.green;
                }
            } else if(td.mainId == 2 && td.isActive) {
                subTaskDetails = subTaskList.GetChild(td.subId - 1).GetComponent<Text>();
                subTaskDetails.text = td.taskDetails;

                if(td.isActive && !td.isFinished){
                    subTaskDetails.color = Color.white;
                } else if(td.isActive && td.isFinished) {
                    subTaskDetails.color = Color.green;
                }
            }
        }
    } //-- UpdateTaskListUI() --

    public void InitMainTask1(TaskData[] taskData) {
        foreach(TaskData td in taskData) {
            if(td.mainId == 1) {
                td.isActive = true;
            } else {
                td.isActive = false;
            }
        }
    } //-- InitMainTask1() --

    public void InitMainTask2(TaskData[] taskData) {
        foreach(TaskData td in taskData) {
            if(td.mainId == 2) {
                td.isActive = true;
            } else {
                td.isActive = false;
            }
        }
    } //-- InitMainTask2() --

    public void ShowTaskList() {
        if(!mainActive) {
            mainTaskContainer.gameObject.SetActive(true);
            mainActive = true;
        } else {
            if(!subActive) {
                subTaskContainer.gameObject.SetActive(true);
                subActive = true;
            } else {
                mainTaskContainer.gameObject.SetActive(false);
                subTaskContainer.gameObject.SetActive(false);
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