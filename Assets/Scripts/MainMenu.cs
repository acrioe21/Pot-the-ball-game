using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

    }
    public void multiPlayerGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void singlePlayerGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void QuitGame()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}
