/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;


public class SceneChangerAndPlayerTeleporter : MonoBehaviour
{
    public string nextSceneName;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

    }

    public void ChangeSceneAndTeleportPlayer(int targetIndex)
    {
        gameManager.targetIndex = targetIndex;
        gameManager.LoadScene(nextSceneName);
    }
}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChangerAndPlayerTeleporter : MonoBehaviour
{
    public string nextSceneName;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void ChangeSceneAndTeleportPlayer()
    {
        SceneManager.LoadScene(nextSceneName);

        if (gameManager != null)
        {
            gameManager.TeleportPlayer(GameObject.FindGameObjectWithTag("Player"));
        }
    }
}
