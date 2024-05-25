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
        if (targetPointsObjects != null)
        {
            if (sceneIndex == 1)
            {
                playerController.jumpforce = 3;
                playerController.walkingSpeed = 2;
                playerController.runningSpeed = 3;
                float newYScale = 0.77f;
                playerController.transform.localScale = new Vector3(playerController.transform.localScale.x, newYScale, playerController.transform.localScale.z);
            }
            if (sceneIndex == 2)
            {
                playerController.jumpforce = 3;
                playerController.walkingSpeed = 4;
                playerController.runningSpeed = 6;
                float newYScale = 0.8f;
                playerController.transform.localScale = new Vector3(playerController.transform.localScale.x, newYScale, playerController.transform.localScale.z);
            }
            if (sceneIndex == 3)
            {
                playerController.jumpforce = 5;
                playerController.walkingSpeed = 5;
                playerController.runningSpeed = 7;
                float newYScale = 1f;
                playerController.transform.localScale = new Vector3(playerController.transform.localScale.x, newYScale, playerController.transform.localScale.z);
            }
            if (sceneIndex == 4)
            {
                playerController.jumpforce = 3;
                playerController.walkingSpeed = 4;
                playerController.runningSpeed = 6;
                float newYScale = 0.8f;
                playerController.transform.localScale = new Vector3(playerController.transform.localScale.x, newYScale, playerController.transform.localScale.z);
            }
            if (sceneIndex == 5)
            {
                playerController.jumpforce = 3;
                playerController.walkingSpeed = 2;
                playerController.runningSpeed = 3;
                float newYScale = 0.77f;
                playerController.transform.localScale = new Vector3(playerController.transform.localScale.x, newYScale, playerController.transform.localScale.z);
            }
            playerController.TriggerTeleport(targetPointsObjects[teleportPointIndex].transform);
            
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            playerUI.DisableChooseMenuUI();
        }
    }
}
