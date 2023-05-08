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
        PlayerPrefs.SetInt("ColOneCollected", 0);
        PlayerPrefs.SetInt("ColTwoCollected", 0);
        PlayerPrefs.SetInt("ColThreeCollected", 0);
        PlayerPrefs.SetInt("ColFourCollected", 0);
        PlayerPrefs.SetInt("ColFiveCollected", 0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}