using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseMenuButton : MonoBehaviour
{
    public int targetSceneIndex;
    public void Telport(int targetTeleportPointIndex)
    {
        TeleportManager.Instance.TeleportPlayer(targetSceneIndex, targetTeleportPointIndex);
    }
}
