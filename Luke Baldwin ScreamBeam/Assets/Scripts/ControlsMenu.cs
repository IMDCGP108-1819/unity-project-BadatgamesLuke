using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsMenu : MonoBehaviour
{

    public void StartGame()
    {
        //Loads Game By looking at the next scene in build settings
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}