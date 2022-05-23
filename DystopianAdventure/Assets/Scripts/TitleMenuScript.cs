using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Script which determines certain characterists of the title scene.
public class TitleMenuScript : MonoBehaviour
{
    public Image loadButtonBackground;
    public Button loadButton;

    void Start()
    {
        DisableLoadGame();
    }

    //Function which disables the load button. 
    //The save feature is not fully functional but it is not worth scrapping alltogether, so for now the burron is just greyed out
    void DisableLoadGame() {
        string path = Application.persistentDataPath + "/player.fun";

        //if (!File.Exists(path))
        //{
        loadButtonBackground.color = UnityEngine.Color.grey;
        loadButton.interactable = false;
        //}
    }

    //Code to quit unity. Attached to quit button
    public void QuitGame () {
        Debug.Log("quit");
        Application.Quit();
    }

    //Code to switch to next scene. Used in start new game button
    public void StartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        //SceneManager.LoadScene(0);
        Time.timeScale = 1;
        //pauseMenu.SetActive(false);
    }

    /*deleted saves. Not currently used but is 
    public void DeleteSave() {
        SerializationManager.DeleteAllSave();
    }*/
}
