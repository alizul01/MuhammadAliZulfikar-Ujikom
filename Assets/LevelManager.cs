using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void GoToScene(string targetScene)
    {
        SceneManager.LoadScene(targetScene);
    }
}
