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
        /*if (playerController != null)
        {
            playerController.enabled = false;
        }*/

        TargetPoints targetPoints = FindObjectOfType<TargetPoints>();
        List<Transform> targetPointsObjects = targetPoints.GetTargetPoints();
        //Debug.Log(targetPointsObjects[0].transform.position);
        if (targetPointsObjects != null)
        {
            playerController.TriggerTeleport(targetPointsObjects[teleportPointIndex].transform);
            /*Vector3 targetPosition = targetPointsObjects[teleportPointIndex].transform.position;
            Debug.Log("Teleporting to target position: " + targetPosition);

            PlayerController player = FindObjectOfType<PlayerController>();
            player.transform.position = targetPosition;
            Debug.Log("Player teleported to: " + player.transform.position);*/

            /*CharacterController player = FindObjectOfType<CharacterController>();
            PlayerController playerController = player.GetComponent<PlayerController>();
            playerController.enabled = false;
            player.transform.position = targetPointsObjects[teleportPointIndex].transform.position;
            //player.enabled = true;
            Debug.Log(55555);*/
        }
        /*if (playerController != null)
        {
            playerController.enabled = true;
        }*/
    }
}
