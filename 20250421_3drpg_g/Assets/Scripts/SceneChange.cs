using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void sceneChange()
    {
        SceneManager.LoadScene("Zone01");
    }
}
