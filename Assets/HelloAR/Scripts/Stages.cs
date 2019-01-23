using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stages : MonoBehaviour
{
    public void ButtonEasy()
    {
        //MazeLoader.mazeRows = 3;
        //MazeLoader.mazeColumns = 6;
        PlayerPrefs.SetInt("mazeRows", 3);
        PlayerPrefs.SetInt("mazeColumns", 6);

        SceneManager.LoadScene("Sandbox");
    }
    public void ButtonNormal()
    {
        PlayerPrefs.SetInt("mazeRows", 6);
        PlayerPrefs.SetInt("mazeColumns", 9);
        SceneManager.LoadScene("Sandbox");
    }
    public void ButtonHard()
    {
        PlayerPrefs.SetInt("mazeRows", 9);
        PlayerPrefs.SetInt("mazeColumns", 9);
        SceneManager.LoadScene("Sandbox");
    }
}