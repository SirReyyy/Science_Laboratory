using UnityEngine;


public class Triggers : MonoBehaviour {
    public TaskManager _taskManager;
    public TaskData _taskData;

    public bool isLaboratory;

    void Start() {
        _taskManager = GameObject.Find("GameManager").GetComponent<TaskManager>();
    } //-- Start() --

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            _taskData.isFinished = true;
            
            if(_taskData.mainId == 1) {
                _taskManager.MainTask1Count++;
            } else {
                _taskManager.MainTask2Count++;
            }

            Destroy(gameObject);
        }
    }
}


/*

Made by : Rey M. Oronos, Jr.
Project : Science Laboratory

*/