using UnityEngine;
using UnityEngine.Animations;

public class Cabinet_Interact : MonoBehaviour, IInteractable {

    public GameObject cabinetPrefab;
    public Animator cabinetAnimator;
    public bool isClose;
    

    void Start() {
        // cabinetAnimator = GameObject.Find("counter_cabinet").GetComponent<Animator>();
        cabinetAnimator = cabinetPrefab.GetComponent<Animator>();
    } //-- Start() --

    public void Interact() {
        if(isClose) {
            cabinetAnimator.SetBool("isClose", false);
            isClose = false;
        } else {
            cabinetAnimator.SetBool("isClose", true);
            isClose = true;
        }
    } //-- Interact() --
}

/*

Made by : Rey M. Oronos, Jr.
Project : Science Laboratory

*/