using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameBtn : MonoBehaviour
{
	public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
