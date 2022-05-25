using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script to restart game after credits roll.
public class EndGameScript : MonoBehaviour
{
    public void restartGame() {
        SceneManager.LoadScene(0);
    }
}
