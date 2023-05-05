using UnityEngine;
using UnityEngine.Animations;

public class Drawer_Interact : MonoBehaviour, IInteractable {

    public GameObject drawerPrefab;
    public Animator drawerAnimator;
    public bool isClose;
    

    void Start() {
        // cabinetAnimator = GameObject.Find("counter_cabinet").GetComponent<Animator>();
        drawerAnimator = drawerPrefab.GetComponent<Animator>();
    } //-- Start() --

    public void Interact() {
        if(isClose) {
            drawerAnimator.SetBool("isClose", false);
            isClose = false;
        } else {
            drawerAnimator.SetBool("isClose", true);
            isClose = true;
        }
    } //-- Interact() --
}

/*

Made by : Rey M. Oronos, Jr.
Project : Science Laboratory

*/