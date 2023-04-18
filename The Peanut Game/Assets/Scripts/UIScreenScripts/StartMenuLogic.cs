using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuLogic : MonoBehaviour
{
    public void Start()
    {
        SceneManager.LoadScene("LevelOneScene");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("InstructionsScreen");
    }

    public void Quit()
    {
        Application.Quit();
    }
}