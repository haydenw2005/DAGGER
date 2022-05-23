using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayGame : MonoBehaviour
{
    public Image saveButtonBackground;
    public Button saveButton;
    public GameObject pauseMenu;


    void Start() {
        saveButtonBackground.color = UnityEngine.Color.grey;
        saveButton.interactable = false;
    }

    public void StartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        //SceneManager.LoadScene(0);
        Time.timeScale = 1;
        //pauseMenu.SetActive(false);
    }

    public void QuitGame () {
        Debug.Log("quit");
        Application.Quit();
    }

    public void ResumeGame() {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
    public void BackToMenu() {
        SceneManager.LoadScene(0);
    }

    public void DeleteSave() {
        SerializationManager.DeleteAllSave();
    }
}
