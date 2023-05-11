using UnityEngine;
using UnityEngine.AI;
using StarterAssets;

public class ChattyPlayerFollow : MonoBehaviour, IInteractable {
    
    public ChattyManager chattyManager;
    public NavMeshAgent chattyAI;

    public GameObject playerObj;
    public FirstPersonController fpController;
    Transform playerTransform;


    void Start() {
        chattyManager = GameObject.Find("GameManager").GetComponent<ChattyManager>();
        fpController = playerObj.GetComponent<FirstPersonController>();
        playerTransform = playerObj.transform;
        
    } //-- Start() --

    void FixedUpdate() {
        chattyAI.SetDestination(playerTransform.position);
    } //-- Update() --

    public void Interact() {
        fpController.ChattyInteract();
    } //-- Interact() --
}


/*

Made by : Rey M. Oronos, Jr.
Project : 

*/