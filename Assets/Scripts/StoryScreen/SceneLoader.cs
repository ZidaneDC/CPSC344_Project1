using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadStoryScene()
    {
        SceneManager.LoadScene("StoryScreen");
    }

    public void LoadLevelOne()
    {
        Debug.Log("Loading level one...");
        SceneManager.LoadScene("LevelOne");
    }

    public void LoadEndingScreen()
    {
        SceneManager.LoadScene("EndingStoryScreen");
    }
}
