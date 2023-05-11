using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ChattyManager : MonoBehaviour {

    public TaskManager _taskManager;
    public Canvas PlayerHUD;
    Transform msgContainer;
    Text msgChatty, txtChatty;
    bool msgIsActive = false;

    List<string> msgCompliments = new List<string> {
        "Way to go, buddy.",
        "Nice find. On to the next one.",
        "Great work there, pal.",
        "You've done it. Let's go home now.",
    };

    List<string> msgTimer = new List<string> {
        "Hi there, fellow science lover. \nChatty here, at your service.",
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

    List<string> msgTask = new List<string> {};

    void Start() {
        _taskManager = GameObject.Find("GameManager").GetComponent<TaskManager>();

        msgContainer = PlayerHUD.transform.Find("Chatty").transform.GetChild(1);
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
            Invoke("HideMessage", 5.0f);
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
        
        if(timeLeft == 595) {
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

    public void TaskMessages() {

    } //-- TaskMessages() --
}


/*

Made by : Rey M. Oronos, Jr.
Project : Science Laboratory

*/