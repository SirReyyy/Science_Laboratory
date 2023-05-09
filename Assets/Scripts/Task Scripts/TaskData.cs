using UnityEngine;

[CreateAssetMenu(menuName = "Task Data")]
public class TaskData : ScriptableObject {
    public int mainId;
    public int subId;
    public bool isActive;
    public bool isFinished;
    public string taskDetails;
    public GameObject requiredItem;

}

/*

Made by : Rey M. Oronos, Jr.
Project : Science Laboratory

*/