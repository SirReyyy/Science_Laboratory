using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class TaskManager : MonoBehaviour {

    // Task List
    private Dictionary<TaskData, Task> m_taskDictionary;
    public List<Task> task {get; private set;}
    public TaskData[] taskData;

    // UI
    public Canvas PlayerHUD; 
    public TaskUI taskUI;
    Text timerUI;
    [HideInInspector]
    public float gameTimeRemaining = 600.0f;
    private TimeSpan time;

    // Exit Trigger
    public GameObject exitTrigger;

    // Task Count Checker
    [HideInInspector]
    public int MainTask1Count, MainTask2Count;

    // Chatty
    public ChattyManager chattyManager;

    // Scene
    public GameSceneManager gameSceneManager;


    void Awake() {
        task = new List<Task>();
        m_taskDictionary = new Dictionary<TaskData, Task>();
    } //-- Awake() --

    void Start() {
        MainTask1Count = 0;
        MainTask2Count = 0;

        MainTask1();
        taskUI.InitMainTask1(taskData);

        time = TimeSpan.FromSeconds(gameTimeRemaining);
        timerUI = PlayerHUD.transform.Find("Header").transform.GetChild(0).gameObject.GetComponent<Text>();

    } //-- Start() --
    
    void Update() {
        CheckGameTime();

        if(MainTask2Count >= 4 && MainTask1Count >= 4) {
            // set exit trigger active
            exitTrigger.SetActive(true);
            MainTaskEnd();
            taskUI.InitMainTaskEnd(taskData);
        } else if(MainTask1Count >= 4) {
            MainTask2();
            taskUI.InitMainTask2(taskData);
        }

        taskUI.UpdateTaskListUI(taskData);
    } //-- Update() --

    public void CheckGameTime() {
        if(gameTimeRemaining > 0) {
            gameTimeRemaining -= Time.deltaTime;
            timerUI.text = TimeSpan.FromSeconds(gameTimeRemaining).ToString("mm':'ss");
        } else {
            gameSceneManager.LoseEnding();
        }
    } //-- CheckGameTime() --

    public void MainTask1() {
        foreach(TaskData td in taskData) {
            if(td.mainId == 1) {
                td.isActive = true;
                td.isFinished = false;
            } else {
                td.isActive = false;
                td.isFinished = false;
            }
            Add(td);
        }
    } //-- MainTask1() --

    public void MainTask2() {
        foreach(TaskData td in taskData) {
            if(td.mainId == 2) {
                td.isActive = true;
            } else {
                td.isActive = false;
                td.isFinished = true;
            }
            Add(td);
        }
    }

    public void MainTaskEnd() {
        foreach(TaskData td in taskData) {
            td.isActive = false;
            td.isFinished = true;
        }
    }

    public void ShowTaskList() {
        taskUI.ShowTaskList();
    } //-- ShowTaskList() --

    public Task Get(TaskData referenceData) {
        if(m_taskDictionary.TryGetValue(referenceData, out Task value)) {
            return value;
        }
        return null;
    } //-- Get
    
    public void Add(TaskData referenceData) {
        if(m_taskDictionary.TryGetValue(referenceData, out Task value)) {
            value.AddToStack();
        } else {
            Task newItem = new Task(referenceData);
            task.Add(newItem);
            m_taskDictionary.Add(referenceData, newItem);
        }
    } //-- Add

    public void Remove(TaskData referenceData) {
        if(m_taskDictionary.TryGetValue(referenceData, out Task value)) {
            value.RemoveFromStack();

            if(value.taskStackSize == 0) {
                task.Remove(value);
                m_taskDictionary.Remove(referenceData);
            }
        }
    } //-- Remove
}


/*

Made by : Rey M. Oronos, Jr.
Project : Science Laboratory

*/