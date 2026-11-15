using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuConfiguration : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SceneGame");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
