using UnityEngine;

public class Task {
    public TaskData data {get; private set;}
    public int taskStackSize {get; private set; }

    public Task(TaskData source) {
        data = source;
        AddToStack();
        CheckRequired(); //--
    } //-- Task

    public void AddToStack() {
        taskStackSize++;
    } //-- AddToStack

    public void RemoveFromStack() {
        taskStackSize--;
    } //-- RemoveFromStack

    public void CheckRequired() {
        if(data.requiredItem == null) {
            data.requiredItem = null;
        }
    }
}


/*

Made by : Rey M. Oronos, Jr.
Project : Science Laboratory

*/