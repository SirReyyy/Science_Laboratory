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

    public void ShowInteract(bool show) {
        if(show) {
            PlayerHUD.transform.GetChild(3).gameObject.SetActive(true);
        } else {
            PlayerHUD.transform.GetChild(3).gameObject.SetActive(false);
        }
    }
}


/*

Made by : Rey M. Oronos, Jr.
Project : Science Laboratory

*/