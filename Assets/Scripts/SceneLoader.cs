using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // to use SceneManager class

public class SceneLoader : MonoBehaviour {

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1); //load next scene
    }

    public void LoadFirstScene()
    {
        FindObjectOfType<GameSession>().RestartScore();
        SceneManager.LoadScene(1); //load first level
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
