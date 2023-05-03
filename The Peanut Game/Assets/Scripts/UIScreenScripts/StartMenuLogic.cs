using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuLogic : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("InstructionsScreen");
    }

    public void ResetProgress()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}