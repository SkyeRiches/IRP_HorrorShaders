using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadShadedLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadUnShadedLevel()
    {
        SceneManager.LoadScene(2);
    }
}
