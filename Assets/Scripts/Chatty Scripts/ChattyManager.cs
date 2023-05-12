using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class ChattyManager : MonoBehaviour {

    public TaskManager _taskManager;
    
    TaskData[] taskList;


    public Canvas PlayerHUD;
    Transform msgContainer;
    Text msgChatty, txtChatty;
    bool msgIsActive = false;
    public bool isCompleted = false;

    List<string> msgCompliments = new List<string> {
        "Storage Room. You can find anything you might need in here.",
        "Better protection than a regular pair of glasses.",
        "White really suits you well, buddy.",
        "Golden gloves, shiny and safe.",
        "I wonder what we could see in the sample that we have.",
        "Don't drop it or else we will pay for it.",
        "The Laboratory Room. Let's go experiment, explore and enjoy.",
        "Great job, pal. I always knew you can do it"
    };

    List<string> msgWarnings = new List<string> {
        "Entering without proper uniform is not allowed in the laboratory.",
        "You can't do the experiment with just that, can you?",
        "This isn't even your laboratory table, is it?",
        "You're already done with the experiment. Don't overdo yourself."
    };

    List<string> msgTimer = new List<string> {
        "Hi there, fellow science lover. Chatty here, at your service.",
        "2 minutes have passed since, pal.",
        "5 minutes remaining my friend.",
        "2 minutes! definitely need to rush now.",
        "1 minute left buddy! let's go all in.",
        "5... 4... 3... 2... 1..."
    };

    List<string> msgRandom = new List<string> {
        "I don't like Science. I love it!",
        "It's fun doing stuffs like this.",
        "As your teacher always says, safety first.",
        "My creator told me I was a real chatterbox.",
        "Explore and experiment to learn new things."
    };

    List<string> msgTask = new List<string> {
        "You've done it. Time to go home now.",
    };


    void Start() {
        _taskManager = GameObject.Find("GameManager").GetComponent<TaskManager>();
        taskList = _taskManager.taskData;
        SetTaskMessages();

        msgContainer = PlayerHUD.transform.Find("Chatty").transform.GetChild(0);
        msgChatty = msgContainer.transform.GetChild(0).gameObject.GetComponent<Text>();
        txtChatty = msgContainer.transform.GetChild(1).gameObject.GetComponent<Text>();

        msgContainer.gameObject.SetActive(false);
    } //-- Start() --

    void Update() {
        TimerMessages();
    } //-- Update() --

    public void ShowMessage(string message) {
        if(!msgIsActive) {
            msgChatty.text = message;
            msgContainer.gameObject.SetActive(true);

            msgIsActive = true;
            Invoke("HideMessage", 3.0f);
        }
        
    } //-- ShowMessage() --

    public void HideMessage() {
        if(msgIsActive) {
            msgContainer.gameObject.SetActive(false);
            msgIsActive = false;
        }
    } //-- HideMessage() --

    public void TimerMessages() {
        int timeLeft = (int)_taskManager.gameTimeRemaining;
        
        if(timeLeft == 598) {
            ShowMessage(msgTimer[0]);
        } else if(timeLeft == 480) {
            ShowMessage(msgTimer[1]);
        } else if(timeLeft == 300) {
            ShowMessage(msgTimer[2]);
        } else if(timeLeft == 120) {
            ShowMessage(msgTimer[3]);
        } else if(timeLeft == 60) {
            ShowMessage(msgTimer[4]);
        } else if(timeLeft == 5) {
            ShowMessage(msgTimer[5]);
        }
    } //-- TimerMessages() -- 

    public void SetTaskMessages() {
        foreach(TaskData td in taskList) {
            msgTask.Add(td.taskDetails);
        }
    } //-- SetTaskMessages() --

    public void TaskMessages() {
        taskList = _taskManager.taskData;
        int activeIndex = 0;

        foreach(TaskData td in taskList) {
            if(td.mainId == 1 && !td.isFinished) {
                activeIndex = td.subId;
                break;
            } else if(td.mainId == 2 && !td.isFinished) {
                activeIndex = td.subId + 4;
                break;
            }
        }

        ShowMessage(msgTask[activeIndex]);
    } //-- TaskMessages() --

    public void ComplimentMessages(int index) {
        ShowMessage(msgCompliments[index]);
    } //-- ComplimentMessages() --

    public void WarningMessages(int index) {
        ShowMessage(msgWarnings[index]);
    } //-- WarningMessages() --
}


/*

Made by : Rey M. Oronos, Jr.
Project : Science Laboratory

*/