using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class TitleMenuScript : MonoBehaviour
{
    public Image loadButtonBackground;
    public Button loadButton;

    void Start()
    {
        DisableLoadGame();
    }

    void DisableLoadGame() {
        string path = Application.persistentDataPath + "/player.fun";

        if (!File.Exists(path))
        {
            loadButtonBackground.color = UnityEngine.Color.grey;
            loadButton.interactable = false;
        }
    }
}
