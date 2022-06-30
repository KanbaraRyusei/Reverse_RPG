using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoder : SingletonMonoBehaviour<SceneLoder>
{
    public static void LoadScene(string name)
    {
        SceneManager.LoadSceneAsync(name);
    }
}
