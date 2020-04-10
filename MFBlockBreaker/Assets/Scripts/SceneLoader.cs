using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SceneLoader : MonoBehaviour
{
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
