using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeMenuScript : MonoBehaviour {
    public void ChangeScene(string scene) {
        SceneManager.LoadScene(scene);
    } //-- ChangeScene() --

    public void PlayGame() {
        ChangeScene("Gameplay");
        Debug.Log("Testing");
    } //-- PlayGame() --

    public void ExitGame() {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    } //-- ExitGame() --
}


/*

Made by : Rey M. Oronos, Jr.
Project : Science Laboratory

*/