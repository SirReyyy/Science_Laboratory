using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    
    public Canvas PlayerHUD;


    void Awake() {
        
    } //-- Awake() --

    public void PickUpNotif(string name) {

    } //-- PickUpNotf() --

    public void UpdateInventoryIcon(int id) {
        PlayerHUD.transform.Find("Inventory").transform.GetChild(id).transform.GetChild(0).gameObject.SetActive(true);
    } //-- UpdateInventoryIcon() --
}


/*

Made by : Rey M. Oronos, Jr.
Project : Science Laboratory

*/