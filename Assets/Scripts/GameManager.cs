/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public int targetIndex = -1;
    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void LoadScene(string nextSceneName)
    {
        SceneManager.LoadScene(nextSceneName);
        if (targetIndex != -1)
        {
            TeleportPlayer();
        }
    }
  public void TeleportPlayer()
    {
        TeleportManager teleportManager = FindObjectOfType<TeleportManager>();
        teleportManager.answerButtons[targetIndex].GetComponent<AnswerButton>().MustDo();
        Debug.Log(7777);
        targetIndex = -1;
        PlayerController playerController = FindObjectOfType<PlayerController>();
        player = playerController.gameObject;
        TeleportTo(teleportManager.teleportTargets[targetIndex]);
        if (teleportManager.teleportTargets[targetIndex] != null && playerController != null)
        {
            player.TriggerTeleport(teleportManager.teleportTargets[targetIndex]);
            //player.transform.position = teleportManager.teleportTargets[targetIndex].position;
            //player.transform.rotation = teleportManager.teleportTargets[targetIndex].rotation;
        }
    }
}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public Transform teleportTarget;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TeleportPlayer(GameObject player)
    {
        if (teleportTarget != null && player != null)
        {
            player.transform.position = teleportTarget.position;
            player.transform.rotation = teleportTarget.rotation;
        }
    }
}
