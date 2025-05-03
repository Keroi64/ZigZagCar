using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChaner : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(0);
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene(1);
    }



}
