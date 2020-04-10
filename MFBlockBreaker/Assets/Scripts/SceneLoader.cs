using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene() 
    {
        //Get the index of the current scene according to the configuration in Build Settings.
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //Change to the next scene.
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadScene(string sceneName) 
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame() 
    {
        /* Platform dependent compilation,
         * build will fail if EditorApplication.isPlaying is used for deployment. */

        //If the game is being played on the Unity Editor.
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #endif

        //If the game is being played on the Microsoft Windows operating system.
        #if UNITY_STANDALONE_WIN
            Application.Quit();
        #endif
    }
}
