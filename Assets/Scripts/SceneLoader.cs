using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadHellScene()
    {
        SceneManager.LoadScene("HellScene");
    }

    public void LoadHeavenScene()
    {
        SceneManager.LoadScene("HeavenScene");
    }

    public void LoadPurgatoryScene()
    {
        SceneManager.LoadScene("PurgatoryScene");
    }
}
