using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public GameObject pauseMenu;
    
    public void StartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }

    public void DeleteSave() {
        SerializationManager.DeleteAllSave();
    }
}
