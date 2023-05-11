using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TaskUI : MonoBehaviour {

    public TaskManager _taskManager;
    // UI
    public Canvas PlayerHUD;
    Transform mainTaskContainer, subTaskContainer, subTaskList;
    Text mainTaskDetails, subTaskDetails;
    
    bool mainActive = false, subActive = false;

    List<string> mainTask = new List<string> {
        "Proper Laboratory \nUniform and Practices",
        "Its time to Explore \nand Experiment",
        "Job well done. \nTime to go home."
    };


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

                mainTaskDetails = mainTaskContainer.Find("MainTask").transform.GetChild(1).GetComponent<Text>();
                mainTaskDetails.text = mainTask[0];

            } else if(td.mainId == 2 && td.isActive) {
                subTaskDetails = subTaskList.GetChild(td.subId - 1).GetComponent<Text>();
                subTaskDetails.text = td.taskDetails;

                if(td.isActive && !td.isFinished){
                    subTaskDetails.color = Color.white;
                } else if(td.isActive && td.isFinished) {
                    subTaskDetails.color = Color.green;
                }

                mainTaskDetails = mainTaskContainer.Find("MainTask").transform.GetChild(1).GetComponent<Text>();
                mainTaskDetails.text = mainTask[1];
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

    public void InitMainTaskEnd(TaskData[] taskData) {
        foreach(TaskData td in taskData){
            if(!td.isFinished) {
                return;
            }

            if(td.subId == 1) {
                subTaskDetails = subTaskList.GetChild(td.subId - 1).GetComponent<Text>();
                subTaskDetails.text = "No task remaining.";
            } else {
                subTaskDetails = subTaskList.GetChild(td.subId - 1).GetComponent<Text>();
                subTaskDetails.text = "";
            }

            mainTaskDetails = mainTaskContainer.Find("MainTask").transform.GetChild(1).GetComponent<Text>();
            mainTaskDetails.text = mainTask[2];
        }
    } //-- InitMainTaskEnd() --

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