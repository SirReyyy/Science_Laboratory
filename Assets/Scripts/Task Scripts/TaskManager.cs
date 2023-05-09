using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TaskManager : MonoBehaviour {
    // Task List
    private Dictionary<TaskData, Task> m_taskDictionary;
    public List<Task> task {get; private set;}
    public TaskData[] taskData;

    // UI
    public TaskUI taskUI;


    void Awake() {
        task = new List<Task>();
        m_taskDictionary = new Dictionary<TaskData, Task>();
    } //-- Awake() --

    void Start() {
        foreach(TaskData i in taskData) {
            Add(i);
        }
    } //-- Start() --
    
    void Update() {
        taskUI.UpdateActiveTask(taskData);
        taskUI.UpdateTaskListUI(taskData);
    }

    public void ShowTaskList() {
        taskUI.ShowTaskList();
    }

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