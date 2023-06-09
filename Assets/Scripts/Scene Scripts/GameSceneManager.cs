using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using StarterAssets;

public class GameSceneManager : MonoBehaviour {

    public FirstPersonController fpController;

    public Canvas PlayerHUD;
    public Canvas GameMenu;

    Transform pauseMenu;
    Transform winMenu;
    Transform loseMenu;

    private bool isPlaying;
    private string sceneName;


    void Start() {
        sceneName = SceneManager.GetActiveScene().name;
        InitScene(sceneName);
    } //-- Start() --

    public void InitScene(string sceneName) {
        if(sceneName == "Home") {
            isPlaying = false;
            MouseCursor(true);
        } else if(sceneName == "Gameplay") {
            Time.timeScale = 1;
            isPlaying = true;
            MouseCursor(false);
            fpController.isCinemachineActive = true;

            pauseMenu = GameMenu.transform.GetChild(0);
            winMenu = GameMenu.transform.GetChild(1);
            loseMenu = GameMenu.transform.GetChild(2);

            pauseMenu.gameObject.SetActive(false);
            winMenu.gameObject.SetActive(false);
            loseMenu.gameObject.SetActive(false);
        }
    }

    public void ChangeScene(string scene) {
        SceneManager.LoadScene(scene);
    } //-- ChangeScene() --

    public void IsPaused() {
        if(isPlaying) {
            PauseGame();
            MouseCursor(true);
        } else {
            ResumeGame();
            MouseCursor(false);
        }
    } //-- IsPaused() --

    public void MouseCursor(bool isVisible) {
        if(isVisible) {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        } else {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.None;
        }
    } //-- MouseCursor() --

    public void PlayGame() {
        ChangeScene("Gameplay");
    } //-- PlayGame() --

    public void ExitGame() {
        // UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    } //-- ExitGame() --

    public void PauseGame() {
        Time.timeScale = 0;
        pauseMenu.gameObject.SetActive(true);
        PlayerHUD.gameObject.SetActive(false);

        isPlaying = false;
        fpController.isCinemachineActive = false;
    } // -- PauseGame() --

    public void ResumeGame() {
        Time.timeScale = 1;
        pauseMenu.gameObject.SetActive(false);
        PlayerHUD.gameObject.SetActive(true);

        isPlaying = true;
        fpController.isCinemachineActive = true;
    } // -- ResumeGame() --

    public void WinEnding() {
        Time.timeScale = 0;
        winMenu.gameObject.SetActive(true);
        PlayerHUD.gameObject.SetActive(false);

        isPlaying = false;
        MouseCursor(true);
        fpController.isCinemachineActive = false;
    } // -- WinEnding() --

    public void LoseEnding() {
        Time.timeScale = 0;
        loseMenu.gameObject.SetActive(true);
        PlayerHUD.gameObject.SetActive(false);

        isPlaying = false;
        MouseCursor(true);
        fpController.isCinemachineActive = false;
    } // -- LoseEnding() --

    public void RestartGame() {
        ChangeScene("Gameplay");
    } // -- RestartGame() --

    public void HomeMenu() {
        ChangeScene("Home");
    } // -- HomeMenu() --
}


/*

Made by : Rey M. Oronos, Jr.
Project : Science Laboratory

*/