using UnityEngine;


public class Triggers : MonoBehaviour {
    public TaskManager _taskManager;
    public TaskData _taskData;
    public ChattyManager chattyManager;
    public GameSceneManager gameSceneManager;

    public bool isExit, isLaboratory;

    void Start() {
        _taskManager = GameObject.Find("GameManager").GetComponent<TaskManager>();
        chattyManager = GameObject.Find("GameManager").GetComponent<ChattyManager>();
        gameSceneManager = GameObject.Find("GameManager").GetComponent<GameSceneManager>();
    } //-- Start() --

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            if(!isExit) {
                _taskData.isFinished = true;

                if(!isLaboratory) {
                    chattyManager.ComplimentMessages(0);
                } else {
                    chattyManager.ComplimentMessages(6);
                }
            
                if(_taskData.mainId == 1) {
                    _taskManager.MainTask1Count++;
                } else {
                    _taskManager.MainTask2Count++;
                }

                Destroy(gameObject);
            } else {
                gameSceneManager.WinEnding();
            }
        }
    }
}


/*

Made by : Rey M. Oronos, Jr.
Project : Science Laboratory

*/