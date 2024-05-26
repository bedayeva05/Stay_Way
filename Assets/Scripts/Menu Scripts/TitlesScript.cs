using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlesScript : MonoBehaviour
{
    public void LoadTitles()
    {
        SceneManager.LoadScene(9);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
