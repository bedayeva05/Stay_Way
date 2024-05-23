using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportManager : MonoBehaviour
{
    public static TeleportManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TeleportPlayer(int sceneIndex, int teleportPointIndex)
    {
        StartCoroutine(Teleport(sceneIndex, teleportPointIndex));
    }

    private IEnumerator Teleport(int sceneIndex, int teleportPointIndex)
    {
        SceneManager.LoadScene(sceneIndex);

        yield return new WaitUntil(() => SceneManager.GetActiveScene().buildIndex == sceneIndex);

        PlayerController playerController = FindObjectOfType<PlayerController>();
        InteractiveMode playerUI = FindObjectOfType<InteractiveMode>();

        TargetPoints targetPoints = FindObjectOfType<TargetPoints>();
        List<Transform> targetPointsObjects = targetPoints.GetTargetPoints();
        if (targetPointsObjects != null && playerController != null)
        {
            playerController.TriggerTeleport(targetPointsObjects[teleportPointIndex].transform);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            playerUI.DisableChooseMenuUI();
            playerController.gameObject.GetComponent<PlayerProgress>().LoadProgress();
        }
    }
}
