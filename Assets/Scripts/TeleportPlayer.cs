using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject player;
    public List<Transform> targetPoints;
    public void TeleportTo(int targetPointIndex)
    {
        if (player != null)
        {
            player.transform.position = targetPoints[targetPointIndex].position;
        }
    }
}
