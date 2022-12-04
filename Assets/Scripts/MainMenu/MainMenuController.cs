using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }

    public void Options()
    {
        SceneManager.LoadScene("Scenes/OptionsMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}