using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public void ChangeSceneToGame()
    {
        SceneManager.LoadSceneAsync("GameScene");
    }
    public void ChangeSceneToEnd()
    {
        SceneManager.LoadScene("FinalScene");
    }
    public void ChangeSceneToIntro()
    {
        SceneManager.LoadScene("IntroScene");
    }
}
