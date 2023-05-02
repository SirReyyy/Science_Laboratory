using UnityEngine;

public class PickUp_Interact : MonoBehaviour, IInteractable {
    
    void Start() {
        
    } //-- Start() --

    public void Interact() {
       Debug.Log("item picked-up");
       Destroy(gameObject);
    } //-- Interact() --
}


/*

Made by : Rey M. Oronos, Jr.
Project : Science Laboratory

*/